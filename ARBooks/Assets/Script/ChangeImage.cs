using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {
    public Sprite _on;
    public Sprite _off;
    private bool flg = true;
    Image img;
    Button btn;
    GameObject recordObject;
    MyRecording script = null;
    bool buttonTag;


    void InteractableChange() {
        if(this.gameObject.name == "Play") {
            btn.interactable = script.PlayButtonTag;
        } else if (this.gameObject.name == "Start") {
            btn.interactable = script.RecoerdButtonTag;
        } else if (this.gameObject.name == "Save") {
            btn.interactable = script.SaveButtonTag;
        }
    }

    void Start() {
        recordObject = GameObject.FindGameObjectWithTag("Record");
        script = recordObject.GetComponent<MyRecording>();
        btn = GetComponent<Button>();
        InteractableChange();
    }

    void Update() {
        InteractableChange();
    }

    public void changeImage(){
        img = GetComponent<Image>();
        img.sprite = (flg) ? _on : _off;
        flg = !flg;
    }
}
