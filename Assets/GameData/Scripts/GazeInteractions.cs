using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeInteractions : MonoBehaviour {
    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    private GameObject crossfire;
    private Color defColor = new Color(0.4f,0.4f,0.4f);
    public Color clickColor = new Color(0.5f, 1f, 0.42f);


    private void Start()
    {
        crossfire = GameObject.Find("GvrReticlePointer");
    }

    void Update() {
        if (!gazedAt) return;
        timer += Time.deltaTime;
        if (!(timer >= gazeTime))
        {
            // var startColor = crossfire.GetComponent<Renderer>().material.color;
            crossfire.GetComponent<Renderer>().material.color = Color.Lerp(defColor, clickColor, timer/gazeTime);
            return;
        }
        ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
        crossfire.GetComponent<Renderer>().material.color = defColor;
        timer = 0f;
    }

    public void PointerEnter() {
        gazedAt = true;
    }

    public void PointerExit() {
        crossfire.GetComponent<Renderer>().material.color = defColor;
        gazedAt = false;
        timer = 0;
    }
}