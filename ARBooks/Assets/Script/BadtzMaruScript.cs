using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadtzMaruScript: MonoBehaviour{
    public Sprite maru;
    public Sprite badtz;
    Image img;
    GameObject Plan;
    GameObject book;
    void Start() {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void DestoryIfExist(){
        book = GameObject.FindGameObjectWithTag("book");
        if ( book == null ) {
            return;
        }
        Destroy(this.gameObject);
    }

    void ChangeImg() {
        Plan = GameObject.FindGameObjectWithTag("AR Plane");
        if (Plan == null){
            img.sprite = badtz;
            return;
        }
        img.sprite = maru;
    }
    void Update() {
        ChangeImg();
        DestoryIfExist();
    }
}
