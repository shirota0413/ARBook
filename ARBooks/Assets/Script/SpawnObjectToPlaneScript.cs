using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnObjectToPlaneScript : MonoBehaviour {
    public GameObject cubePrefab;
    GameObject spawnObject;
    ARRaycastManager arRaycastManager;
    int i = 0;

    GameObject modeButton;
    ModeButtonScript script;
    bool mode;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start() {
        arRaycastManager = GetComponent<ARRaycastManager>();
        modeButton = GameObject.Find("Canvas/ModeButton");
        script = modeButton.GetComponent<ModeButtonScript>();
    }

    // Update is called once per frame
    void Update() {
        mode = script.getMode();
        if (Input.touchCount > 0 && mode) {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) {
                Pose hitPose = hits[0].pose;
                Debug.Log("if文");
                if (spawnObject == null) {
                    spawnObject = Instantiate(cubePrefab, hitPose.position, Quaternion.identity);
                    i += 1;
                } else {
                    Debug.Log("動かします");
                    spawnObject.transform.position = hitPose.position;
                }
            }
        }
    }
}
