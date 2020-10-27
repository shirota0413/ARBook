using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyScript : MonoBehaviour {
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
