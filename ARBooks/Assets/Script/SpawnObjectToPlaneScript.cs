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
    PropertyScript script = null;

    ARPlaneManager planeManager;
    bool setActivePlane = false;


    void setPlane() {
        if (setActivePlane) {
            foreach (var plane in planeManager.trackables){
                plane.gameObject.SetActive(false);
            }
        } else  {
             foreach (var plane in planeManager.trackables){
                plane.gameObject.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start() {
        arRaycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update() {
        setPlane();
        if (Input.touchCount > 0) {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) {
                Pose hitPose = hits[0].pose;
                if (spawnObject == null) {
                    spawnObject = Instantiate(cubePrefab, hitPose.position, Quaternion.identity);
                    bookObject = GameObject.FindGameObjectWithTag("book");
                    script = bookObject.GetComponent<PropertyScript>();
                    setActivePlane = true;
                    i += 1;
                } else if(script.Property) {
                    setActivePlane = false;
                    spawnObject.transform.position = hitPose.position;
                }
            }
        }
        if (script != null) {
            if (!script.Property ) {
                setActivePlane = true;
            }
        }
    }
}
