using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.EventSystems;

public class PageCurlScript : MonoBehaviour {
    // Start is called before the first frame update
    bool NextCurl = false;
    bool BackCurl = true;
    
    public GameObject leftPage;
    public GameObject rightPage;

    float rightAfter = 0;
    float leftAfter = 0;
    float rightCalRotate = 0;
    float leftCalRotate = 0;


    //calRotate 負の時は，ダメ
    //calRotate　正の時　ok
    public void SwitchPageCurl() {
        if ((this.transform.eulerAngles.z <= 0.5f || Mathf.Abs(this.transform.eulerAngles.z)  >= 170)  && (rightCalRotate >= 0 &&  leftCalRotate <=0)) {
            NextCurl = !NextCurl;
            BackCurl = !BackCurl;
        }
    }

    void Update() {
        if (this.transform.eulerAngles.z < 180 && NextCurl) {
            this.transform.Rotate(0, 0, 1.5f, Space.World );
        } else if (this.transform.eulerAngles.z  > 0.5 && BackCurl) {
            this.transform.Rotate (0, 0, -1.5f, Space.World );
        }
        rightCalRotate = rightAfter - rightPage.transform.eulerAngles.z;
        leftCalRotate = leftAfter - leftPage.transform.eulerAngles.z;
        rightAfter = rightPage.transform.eulerAngles.z;
        leftAfter = leftPage.transform.eulerAngles.z;
    }
}
