using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeButtonScript : MonoBehaviour {
    private bool Mode = true;

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick(){
        if (Mode) {
            this.GetComponentInChildren<Text>().text = "読書";
        } else {
            this.GetComponentInChildren<Text>().text = "移動";
        }
        Mode = !Mode;
    }
    //getter
    public bool getMode() {
        return Mode;
    }

    
}
