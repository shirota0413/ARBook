using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.EventSystems;

public class PageCurlScript : MonoBehaviour {
    // Start is called before the first frame update
    bool NextCurl = false;
    bool BackCurl = true;

    GameObject modeButton;
    ModeButtonScript script;
    GameObject textPanel;
    BookTextScript textScript;
    bool mode;

    public string BookText;

    void Start() {
        textPanel = GameObject.Find("Canvas/TextPanel/Text");
        textScript = textPanel.GetComponent<BookTextScript>();
    }

    public void SwitchPageCurl() {
        if ((this.transform.eulerAngles.z <= 0.5f || Mathf.Abs(this.transform.eulerAngles.z)  >= 170)) {
            NextCurl = !NextCurl;
            BackCurl = !BackCurl;
            Debug.Log(BookText);
            textScript.SetText(BookText);
        }
    }

    void Update() {
        if (this.transform.eulerAngles.z < 180 && NextCurl) {
            this.transform.Rotate(0, 0, 1.5f, Space.World );
        } else if (this.transform.eulerAngles.z  > 0.5 && BackCurl) {
            this.transform.Rotate (0, 0, -1.5f, Space.World );
        }
    }
}
