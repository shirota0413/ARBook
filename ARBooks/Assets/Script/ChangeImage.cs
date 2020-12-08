using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {
    public Sprite _on;
    public Sprite _off;
    private bool flg = true;
    Image img;

    public void changeImage(){
        img = GetComponent<Image>();
        img.sprite = (flg) ? _on : _off;
        flg = !flg;
    }
}
