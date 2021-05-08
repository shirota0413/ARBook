using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//録音シーンで本の文章を表示するためのデータを読み込む
public class StoryFileRead : MonoBehaviour{
    // Start is called before the first frame update
    GameObject textPanel;
    DisplayText displayTextScript;
    List<string> strArray = new List<string>();
    int pageCount = 0;

    public TextAsset RawTextFile;

    //ファイルに書かれている文章の読み込み
    void BookTextRead() {
        using (StringReader fs = new StringReader(RawTextFile.text))　{
            while (fs.Peek() != -1)　{
                strArray.Add(fs.ReadLine());
            }
        }
        strArray.Add("録音終了しました．");
    }
    
    //次の文章を表示している．
    public void NextStoryText() {
        if (pageCount < 17) {
            pageCount += 1;
            Debug.Log(strArray[pageCount]);
            displayTextScript.ReplaceText(strArray[pageCount]);
        }
    }

    //1行目の文章を表示している
    void Start(){
        textPanel = GameObject.Find("Canvas/TextPanel/Text");
        displayTextScript = textPanel.GetComponent<DisplayText>();
        BookTextRead();
        displayTextScript.ReplaceText(strArray[pageCount]);
    }


    
}
