using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCameraTest : MonoBehaviour {
    Camera myCamera;
    // Start is called before the first frame update
    void Start() {
        //canvas.GetComponent<Canvas> (). = Camera.main;
        myCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        Canvas theCanvas = GetComponent<Canvas>();
        theCanvas.worldCamera = myCamera;
        Debug.Log(theCanvas.worldCamera);
    }

    // Update is called once per frame
}
