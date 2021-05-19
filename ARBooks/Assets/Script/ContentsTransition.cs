using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


//ページに適した音声とオブジェクトの再生・生成を行うクラス
public class ContentsTransition : MonoBehaviour　{
    public GameObject leftPage;
    public GameObject rightPage;

    //Canvas
    DisplayText displayTextScript;
    public string bookText;

    //Audion
    //fileNameとは，このページに適用する音声ボイスの番号
    public string fileName;
    string clipPath;
    AudioSource audioSource;
    bool playSound = true;
    AudioClip audioClip;

    //VoiceToggleScript
    VoiceToggle voiceToggleScript = null;
    //録音とゆっくりの音声の切り替えが起こったか判断するために1つ前の録音かゆっくりどちらの状態だったかを保存する変数
    bool beforTag = true;

    void Start() {
        GameObject textPanel;
        GameObject audioSourceObject;
        GameObject voiceToggle;

        textPanel = GameObject.Find("Canvas/TextPanel/Text");
        displayTextScript = textPanel.GetComponent<DisplayText>();

        audioSourceObject = GameObject.Find("audioSourceObject");
        audioSource = audioSourceObject.GetComponent<AudioSource>();

        voiceToggle = GameObject.FindGameObjectWithTag("VoiceToggle");
        voiceToggleScript = voiceToggle.GetComponent<VoiceToggle>();
        LoudClip();
    }

    //本が生成された時と録音ボイスとゆっくりボイスの切り替えがあったときに，音声データの読み込みを行っている．
    //cilipPathは，voiceの保存先のパスとfileNameでできている
    void LoudClip() {
        if(voiceToggleScript.VoiceProperty != beforTag) {
            if (voiceToggleScript.VoiceProperty) {
                clipPath = Path.Combine(UnityEngine.Application.persistentDataPath + "/voice/Pig_RecordVoice/", fileName + ".wav");
                using (WWW www = new WWW("file://" + clipPath)) {
                    audioClip = www.GetAudioClip(false, true);
                    if (audioClip.loadState != AudioDataLoadState.Loaded) {
                        //ここにロード失敗処理
                        Debug.Log("Failed to load AudioClip.");
                    }
                }
            } else if (!voiceToggleScript.VoiceProperty) {
                clipPath = Path.Combine("Pig_DefultVoice", fileName);
                audioClip = (AudioClip)Resources.Load(clipPath);
            }
            beforTag = voiceToggleScript.VoiceProperty;
        }
    }

    void OnSound() {
        if (playSound) {
            audioSource.clip = audioClip;
            Debug.Log(audioSource.clip);
            audioSource.Play();
            playSound = false;  
        } 
    }

    void OffSound() {
        if (!playSound) {
            audioSource.Stop();
            playSound = true; 
        }
    }

    void Update()　{
        LoudClip();
        //ページの切り替えを判断している．
        if (rightPage.transform.eulerAngles.z < 5 && leftPage.transform.eulerAngles.z > 175) {
            displayTextScript.ReplaceText(bookText);
            OnSound();
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
        } else {
            OffSound();
            foreach (Transform child in transform) {
                child.gameObject.SetActive(false);
            }
        }
    }
}
