using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolor : MonoBehaviour
{


    public void Recol() {
        // var col1 = new Color(0.702f,0.888f,1);
        // var col2 = new Color(0.783f,0.783f,0.783f);
        var col1 = Color.white;
        var col2 = new Color(0.702f,0.888f,1);
        gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color != col1 ? col1 : col2;
    }
}
