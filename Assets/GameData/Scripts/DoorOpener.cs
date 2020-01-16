using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {
    public GameObject doorPivot;

    private bool open;

    private void Update() {
        var rotation = doorPivot.transform.rotation;
        var end = Quaternion.Euler(rotation.eulerAngles.x, open ? 80 : 180, rotation.eulerAngles.z);
        if (Mathf.Abs(rotation.eulerAngles.y - end.eulerAngles.y) < 2) return;
        rotation = Quaternion.RotateTowards(rotation, end, Time.deltaTime * 50);
        doorPivot.transform.rotation = rotation;
    }

    public bool IsOpen() {
        var rotation = doorPivot.transform.rotation;
        var end = Quaternion.Euler(rotation.eulerAngles.x, 80, rotation.eulerAngles.z);
        return (Mathf.Abs(rotation.eulerAngles.y - end.eulerAngles.y) < 2);
    }
    
    public bool IsClosed() {
        var rotation = doorPivot.transform.rotation;
        var end = Quaternion.Euler(rotation.eulerAngles.x, 180, rotation.eulerAngles.z);
        return (Mathf.Abs(rotation.eulerAngles.y - end.eulerAngles.y) < 2);
    }

    public void OpenDoor() {
        open = true;
    }

    public void CloseDoor() {
        open = false;
    }
}