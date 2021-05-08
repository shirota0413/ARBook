using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadtzMaru: MonoBehaviour{
    public Sprite maru;
    public Sprite badtz;
    Image img;
    GameObject plan;
    GameObject book;

    void Start() {
        img = GetComponent<Image>();
    }


    void DestoryIfExist(){
        book = GameObject.FindGameObjectWithTag("book");
        if ( book == null ) {
            return;
        }
        Destroy(this.gameObject);
    }

    //○画像と×画像の切り替え
    void ChangeImg() {
        plan = GameObject.FindGameObjectWithTag("AR Plane");
        if (plan == null){
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
