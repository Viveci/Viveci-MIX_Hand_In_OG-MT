using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour {
    
    public Camera cam;

    Color one, two;
    
    void Start () {

        one = new Color(40f, 116f, 40f,1f);
        two = new Color(40f, 116f, 116f,1f);

        cam.backgroundColor = one;
    }

    void Update()
    {
        cam.backgroundColor = one;
        Debug.Log(one.ToString());
        Debug.Log(cam.backgroundColor.ToString());
    }
}
