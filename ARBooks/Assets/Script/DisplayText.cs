using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//画面に文章を表示する
public class DisplayText : MonoBehaviour {
    public Text displayText;

    public int ReplaceText(string bookText){
        bookText = bookText.Replace(" ", "\n");
        displayText.text = bookText;
        return 0;
    }
}
