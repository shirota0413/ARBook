using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//録音シーンにある再生・録音ボタンの画像をof/offによって差し替えるクラス
public class ChangeRecordButtonImage : MonoBehaviour {
    public Sprite on;
    public Sprite off;
    private bool flg = true;
    Image img;
    Button btn;
    GameObject recordObject;
    MyRecording myRecordingScript = null;
    bool buttonTag;


    void InteractableChange() {
        if(this.gameObject.name == "Play") {
            btn.interactable = myRecordingScript.PlayButtonTag;
        } else if (this.gameObject.name == "Start") {
            btn.interactable = myRecordingScript.RecoerdButtonTag;
        } else if (this.gameObject.name == "Save") {
            btn.interactable = myRecordingScript.SaveButtonTag;
        }
    }

    void Start() {
        recordObject = GameObject.FindGameObjectWithTag("Record");
        myRecordingScript = recordObject.GetComponent<MyRecording>();
        btn = GetComponent<Button>();
        InteractableChange();
    }

    void Update() {
        InteractableChange();
    }


    public void ChangeButtonImage(){
        img = GetComponent<Image>();
        img.sprite = (flg) ? on : off;
        flg = !flg;
    }
}
