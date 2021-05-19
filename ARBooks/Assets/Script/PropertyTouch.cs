using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//本の真ん中をタップしている状態かどうか判定するクラス
public class PropertyTouch : MonoBehaviour {
    private bool tag;

    public bool Property {
        get{ return tag; }
        set{ tag = value; }
    }

    public void TouchDown(){
		tag = true;
	}

    public void TouchUp() {
        tag = false;
    }
}
