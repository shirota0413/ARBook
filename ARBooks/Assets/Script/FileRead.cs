using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileRead : MonoBehaviour{
    // Start is called before the first frame update
    GameObject textPanel;
    BookTextScript textScript;
    List<string> strArray = new List<string>();
    int i = 0;

    public TextAsset RawTextFile;

    void Read() {
        //string StoryPath = "Resources/Story/Pig_Story.txt";
        //Debug.Log("Name:" + StoryPath);
        using (StringReader fs = new StringReader(RawTextFile.text))　{
            while (fs.Peek() != -1)　{
                strArray.Add(fs.ReadLine());
            }
        }
        strArray.Add("録音終了しました．");
    }
    
    public void NextText() {
        if (i < 17) {
            i += 1;
            textScript.SetText(strArray[i]);
        }
    }

    void Start(){
        textPanel = GameObject.Find("Canvas/TextPanel/Text");
        textScript = textPanel.GetComponent<BookTextScript>();
        Read();
        textScript.SetText(strArray[i]);
    }


    
}
