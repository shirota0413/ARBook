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

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    GameObject bookObject;
    PropertyScript script;

    // Start is called before the first frame update
    void Start() {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0) {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) {
                Pose hitPose = hits[0].pose;
                if (spawnObject == null) {
                    spawnObject = Instantiate(cubePrefab, hitPose.position, Quaternion.identity);
                    bookObject = GameObject.FindGameObjectWithTag("book");
                    script = bookObject.GetComponent<PropertyScript>();
                    i += 1;
                } else if(script.Property) {
                    spawnObject.transform.position = hitPose.position;

                }
            }
        }
    }
}
