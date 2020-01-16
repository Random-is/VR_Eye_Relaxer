using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleInteractions : MonoBehaviour {
    private bool toDown;
    public GameObject handle;

    void Update() {
        var rotation = handle.transform.rotation;
        var end = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, toDown ? -20 : 0);
        if (Mathf.Abs(rotation.eulerAngles.z - end.eulerAngles.z) < 2) return;
        rotation = Quaternion.RotateTowards(rotation, end, Time.deltaTime * 50);
        handle.transform.rotation = rotation;
    }

    public void PointerEnter() {
        toDown = true;
    }

    public void PointerExit() {
        toDown = false;
    }
}