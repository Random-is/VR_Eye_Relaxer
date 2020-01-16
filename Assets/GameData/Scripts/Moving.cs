using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
    public GameObject player;
    private bool toMain;

    private bool isStart = false;

    void Update() {
        if (!isStart) return;
        var doorOpener = gameObject.GetComponent<DoorOpener>();
        doorOpener.OpenDoor();
        if (!doorOpener.IsOpen() && toMain) return;
        var position = player.transform.position;
        var end = new Vector3(position.x, position.y, toMain ? -22f : -2f);
        player.transform.position = Vector3.MoveTowards(position, end, Time.deltaTime * 5);
        if (!(Mathf.Abs(position.z - end.z) < 0.01f)) return;
        doorOpener.CloseDoor();
        isStart = false;
    }

    public void GoToTrainingRoom() {
        isStart = true;
        toMain = false;
    }
    
    public void GoToMainRoom() {
        isStart = true;
        toMain = true;
    }
}
