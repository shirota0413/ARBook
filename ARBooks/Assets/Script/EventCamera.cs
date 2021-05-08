using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCamera : MonoBehaviour {
    Camera myCamera;

    //Event Cameraの設定
    void Start() {
        myCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        Canvas theCanvas = GetComponent<Canvas>();
        theCanvas.worldCamera = myCamera;
        Debug.Log(theCanvas.worldCamera);
    }
}
