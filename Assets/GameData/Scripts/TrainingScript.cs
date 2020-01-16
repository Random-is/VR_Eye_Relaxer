using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TrainingScript : MonoBehaviour {
    public TextMeshPro text;
    public TextMeshPro textMorganie;
    public GameObject centerPoint;
    private bool startTr;
    private int part;
    private float timer;
    private float timerMorganie;
    private float timerCheck;
    private float checkWait;
    public float timeBetweenTrainType = 2f;
    private bool[] trainMas = new bool[3];
    private List<int> trainList = new List<int>();
    private bool complete;
    private float delay = 2f;
    private bool onCenter;
    private float timerLost;
    private float lostWait = 1.5f;
    private int rightCount;
    private int failCount;
    public TextMeshPro textScore;

    private string[] texts = {
        "Вы не выбрали ни одного вида тренировки",
        "Наведите указатель на сферу на стене",
        "Сейчас начнется",
        "Следите глазами за зеленым кругом",
        "Вы великолепны!",
        "Быстро моргайте в течение 3 секунд",
        "Быстро моргайте в течение 2 секунд",
        "Быстро моргайте в течение 1 секунды"
    };

    private readonly int[] speedMas = {
        6, 6, 6
    };

    private static readonly Vector3 Top = new Vector3(0, 9.84f, 1.8f);
    private static readonly Vector3 Bot = new Vector3(0, 3f, 4.14f);
    private static readonly Vector3 Left = new Vector3(-5.30f, 6.46f, 4.14f);
    private static readonly Vector3 Right = new Vector3(5.30f, 6.46f, 4.14f);
    private static readonly Vector3 Center = new Vector3(0, 6.45f, 4.14f);
    private static readonly Vector3 TopLeft = new Vector3(-4.30f, 9.84f, 1.8f);
    private static readonly Vector3 TopRight = new Vector3(4.30f, 9.84f, 1.8f);
    private static readonly Vector3 BotLeft = new Vector3(-4.30f, 3f, 4.14f);
    private static readonly Vector3 BotRight = new Vector3(4.30f, 3f, 4.14f);


    private readonly Vector3[][] vecMas = {
        new[] {
            Top,
            Bot,
            Right,
            Left,
            TopRight,
            BotLeft,
            TopLeft,
            BotRight,
            Center,
        },
        new [] {
            BotLeft,
            Left,
            Top,
            Right,
            BotRight,
            Right,
            Top,
            Left,
            BotLeft,
            TopRight,
            Right,
            Bot,
            Left,
            TopLeft,
            Left,
            Bot,
            Right,
            TopRight,
            Center
        },
        new[] {
           TopLeft,
           TopRight,
           BotLeft,
           BotRight,
           TopLeft,
           TopRight,
           BotLeft,
           BotRight,
           Center
        }
    };
    System.Random rnd = new System.Random();

    public GameObject spfere;

    private void Start() {
        spfere.SetActive(false);
    }

    private void Update() {
        
        if (trainList.Count == 0) return;
        if (!startTr) return;
        if (!onCenter) return;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (centerPoint.activeSelf)
            {
                textScore.text = "Очки: " + rightCount + "/" + (rightCount+failCount);
                rightCount++;
                centerPoint.SetActive(false);
                timerCheck = 0;
                checkWait = rnd.Next(1, 3);
            }
            else
            {
                textScore.text = "Очки: " + rightCount + "/" + (rightCount+failCount);
                failCount++;
            }
        }
        var trainType = trainList[0];
        if (part != vecMas[trainType].Length && centerPoint.activeSelf)
        {
            timerLost += Time.deltaTime;
            if (timerLost >= lostWait)
            {
                textScore.text = "Очки: " + rightCount + "/" + (rightCount+failCount);
                failCount++;
                centerPoint.SetActive(false);
                timerCheck = 0;
                checkWait = rnd.Next(1, 3);
            }
        }

        if (part != vecMas[trainType].Length && !centerPoint.activeSelf)
        {
            timerCheck += Time.deltaTime;
            if (timerCheck >= checkWait)
            {
                centerPoint.SetActive(true);
                timerLost = 0;
            }
        }

        
        if (part == vecMas[trainType].Length) {
            textMorganie.text = texts[5];
            timerMorganie += Time.deltaTime;
            if (timerMorganie >= delay + 1f && timerMorganie <= delay + 2f) textMorganie.text = texts[6];
            if (timerMorganie >= delay + 2f && timerMorganie <= delay + 3f) textMorganie.text = texts[7];
            if (!(timerMorganie >= delay + 3f)) return;
            textMorganie.text = "";
            timerMorganie = 0;
            timer = 0;
            part = 0;
            trainList.RemoveAt(0);
        }

        if (trainList.Count == 0) {
            complete = true;
            text.text = texts[4];
            spfere.SetActive(false);
            return;
        }

        spfere.SetActive(true);
        if (part == 0) {
            timer += Time.deltaTime;
            if (!(timer >= timeBetweenTrainType)) return;
        }

        var position = spfere.transform.position;
        spfere.transform.position =
            Vector3.MoveTowards(position, vecMas[trainType][part], Time.deltaTime * speedMas[trainType]);
        if (Mathf.Abs(spfere.transform.position.x - vecMas[trainType][part].x) < 0.01f &&
            Mathf.Abs(spfere.transform.position.y - vecMas[trainType][part].y) < 0.01f &&
            Mathf.Abs(spfere.transform.position.z - vecMas[trainType][part].z) < 0.01f)
            part++;
    }

    private bool IsSelectTrain() {
        return trainMas.Any(t => t);
    }

    public void ResetTraining() {
        startTr = false;
        text.text = IsSelectTrain() ? texts[1] : texts[0];
        timer = 0;
        timerMorganie = 0;
        complete = false;
        part = 0;
        spfere.transform.position = Center;
        spfere.SetActive(false);
        centerPoint.SetActive(false);
        timerCheck = 0;
        checkWait = 0;
        timerLost = 0;
        failCount = 0;
        rightCount = 0;
        textScore.text = "";
        textMorganie.text = "";
    }

    private List<int> GenerateTrainList() {
        var result = new List<int>();
        for (var i = 0; i < trainMas.Length; i++)
            if (trainMas[i])
                result.Add(i);
        result.AddRange(result);
        return result;
    }

    // private static List<T> Randomize<T>(IList<T> list) {
    //     var randomizedList = new List<T>();
    //     var rnd = new System.Random();
    //     while (list.Count > 0) {
    //         var index = rnd.Next(0, list.Count);
    //         randomizedList.Add(list[index]);
    //         list.RemoveAt(index);
    //     }
    //     return randomizedList;
    // }

    public void PointerEnter() {
        if (complete) return;
        if (!IsSelectTrain()) return;
        onCenter = true;
        text.text = !startTr ? texts[2] : texts[3];
    }

    public void PointerExit() {
        if (complete) return;
        if (!IsSelectTrain()) return;
        onCenter = false;
        text.text = texts[1];
    }

    public void PointerClick() {
        if (!IsSelectTrain()) return;
        if (startTr) return;
        trainList = GenerateTrainList();
        textScore.text = "Очки: 0/0";
        startTr = true;
        text.text = texts[3];
    }

    public void ChangeTrain(int type) {
        trainMas[type] = !trainMas[type];
        text.text = IsSelectTrain() ? texts[1] : texts[0];
    }
}