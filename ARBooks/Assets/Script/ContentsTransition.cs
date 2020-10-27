using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsTransition : MonoBehaviour
{
    public GameObject leftPage;
    public GameObject rightPage;

    void Update()
    {
        if (rightPage.transform.eulerAngles.z < 5 && leftPage.transform.eulerAngles.z > 175) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
        } else {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
        }
    }
}
