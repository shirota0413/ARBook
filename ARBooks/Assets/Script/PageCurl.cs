using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.EventSystems;


//本をスワイプすることによってページをめくるクラス
public class PageCurl : MonoBehaviour {
    // Start is called before the first frame update
    bool nextCurl = false;
    bool backCurl = true;
    
    public GameObject leftPage;
    public GameObject rightPage;

    float rightAfter = 0;
    float leftAfter = 0;
    float rightCalRotate = 0;
    float leftCalRotate = 0;

    AudioClip bookFlipSE;
    AudioSource audioSource;
    

    
    //ページが動いているか動いていないか確認する．ページが動いていない時は，Trueとなりめくることができる
    public void SwitchPageCurl() {
        if ((this.transform.eulerAngles.z <= 0.5f || Mathf.Abs(this.transform.eulerAngles.z)  >= 170)  && (rightCalRotate >= 0 &&  leftCalRotate <=0)) {
            nextCurl = !nextCurl;
            backCurl = !backCurl;
            audioSource.PlayOneShot(bookFlipSE);
        }
    }

    void Start() {
        bookFlipSE = Resources.Load<AudioClip>("Audio/BookFlip");
        audioSource = GetComponent<AudioSource>();
    }

    //ページを動かしている．
    //また，ページの状態を保存している
    void Update() {
        if (this.transform.eulerAngles.z < 180 && nextCurl) {
            this.transform.Rotate(0, 0, 1.5f, Space.World );
        } else if (this.transform.eulerAngles.z  > 0.5 && backCurl) {
            this.transform.Rotate (0, 0, -1.5f, Space.World );
        }
        rightCalRotate = rightAfter - rightPage.transform.eulerAngles.z;
        leftCalRotate = leftAfter - leftPage.transform.eulerAngles.z;
        rightAfter = rightPage.transform.eulerAngles.z;
        leftAfter = leftPage.transform.eulerAngles.z;
    }
}
