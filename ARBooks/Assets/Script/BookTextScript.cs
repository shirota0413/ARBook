using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookTextScript : MonoBehaviour
{
    public Text text;

    public string SetText(string BookText){
        return text.text = BookText;
    }

}
