using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//表示されている注意書きと○・×を削除するクラス
public class CautionDestory : MonoBehaviour {
    

    void DestoryIfExist(){
        GameObject book;
        book = GameObject.FindGameObjectWithTag("book");
        if ( book == null ) {
            return;
        }
        Destroy(this.gameObject);
    }

    void Update() {
        DestoryIfExist();
    }
}
