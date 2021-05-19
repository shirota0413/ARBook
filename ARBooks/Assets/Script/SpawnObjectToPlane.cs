using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


//bookオブジェクトの生成とPlaneの表示を切り替えるクラス
public class SpawnObjectToPlane : MonoBehaviour {
    public GameObject cubePrefab;
    GameObject spawnObject;
    ARRaycastManager arRaycastManager;
    int i = 0;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    GameObject bookObject;
    PropertyTouch propertyTouchscript = null;

    ARPlaneManager planeManager;
    bool setActivePlane = false;

    AudioSource audioSource;

    //Planeの可視化の切り替え
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

    void Start() {
        arRaycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update() {
        setPlane();
        if (Input.touchCount > 0) {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) {
                Pose hitPose = hits[0].pose;
                if (spawnObject == null) {
                    audioSource.Play();
                    spawnObject = Instantiate(cubePrefab, hitPose.position, Quaternion.identity);
                    bookObject = GameObject.FindGameObjectWithTag("book");
                    propertyTouchscript = bookObject.GetComponent<PropertyTouch>();
                    setActivePlane = true;
                    i += 1;
                } else if(propertyTouchscript.Property) {
                    setActivePlane = false;
                    spawnObject.transform.position = hitPose.position;
                }
            }
        }
        if (propertyTouchscript != null) {
            if (!propertyTouchscript.Property ) {
                setActivePlane = true;
            }
        }
    }
}
