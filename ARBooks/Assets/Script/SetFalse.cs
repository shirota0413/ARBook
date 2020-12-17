using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalse : MonoBehaviour {
    GameObject book;
    // Start is called before the first frame update
    void DestoryIfExist(){
        book = GameObject.FindGameObjectWithTag("book");
        if ( book == null ) {
            return;
        }
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update() {
        DestoryIfExist();
    }
}
