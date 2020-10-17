using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnObjectToPlane : MonoBehaviour {
    public GameObject cubePrefab;
    GameObject spawnObject;
    ARRaycastManager arRaycastManager;
    int i = 0;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start() {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && i == 0) {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) {
                Pose hitPose = hits[0].pose;
                if (spawnObject == null) {
                    spawnObject = Instantiate(cubePrefab, hitPose.position, hitPose.rotation);
                    i += 1;
                }
                // } else {
                //     //spawnObject.transform.position = hitPose.position;
                // }
            
            }
            
        }
        
    }
}
