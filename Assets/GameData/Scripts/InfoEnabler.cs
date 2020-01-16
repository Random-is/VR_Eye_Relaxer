using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoEnabler : MonoBehaviour
{
    public GameObject mainInfo;
    public GameObject trainingInfo;
    
    private Color blue = new Color(0.702f,0.888f,1);

    private void Start()
    {
        mainInfo.SetActive(false);
        trainingInfo.SetActive(false);
    }

    public void MainInfoChangeActive()
    {
        mainInfo.SetActive(!mainInfo.activeSelf);
        gameObject.GetComponent<Renderer>().material.color = mainInfo.activeSelf ? blue : Color.white;
    }
    
    public void TrainingInfoChangeActive()
    {
        trainingInfo.SetActive(!trainingInfo.activeSelf);
        gameObject.GetComponent<Renderer>().material.color = trainingInfo.activeSelf ? blue : Color.white;

    }
}
