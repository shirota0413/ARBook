using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ContentsTransition : MonoBehaviour
{
    public GameObject leftPage;
    public GameObject rightPage;

    GameObject textPanel;
    BookTextScript textScript;
    public string BookText;

    public string FileName;
    string ClipPath;
    AudioSource audioSource;
    GameObject audioSourceObject;
    bool SoundOn = true;
    AudioClip audioClip;

    GameObject toggle;
    ToggleScript script = null;
    bool beforTag = true;

    void Start() {
        textPanel = GameObject.Find("Canvas/TextPanel/Text");
        textScript = textPanel.GetComponent<BookTextScript>();
        audioSourceObject = GameObject.Find("audioSourceObject");
        audioSource = audioSourceObject.GetComponent<AudioSource>();
        toggle = GameObject.FindGameObjectWithTag("toggle");
        script = toggle.GetComponent<ToggleScript>();
        LoudClip();
    }

    void LoudClip() {
        if(script.Property != beforTag) {
            if (script.Property) {
                ClipPath = Path.Combine(UnityEngine.Application.persistentDataPath + "/voice/Pig_RecordVoice/", FileName + ".wav");
                using (WWW www = new WWW("file://" + ClipPath)) {
                    audioClip = www.GetAudioClip(false, true);
                    if (audioClip.loadState != AudioDataLoadState.Loaded) {
                        //ここにロード失敗処理
                        Debug.Log("Failed to load AudioClip.");
                    }
                }
            } else if (!script.Property) {
                ClipPath = Path.Combine("Pig_DefultVoice", FileName);
                audioClip = (AudioClip)Resources.Load(ClipPath);
            }
            beforTag = script.Property;
        }
    }

    void OnSound() {
        if (SoundOn) {
            audioSource.clip = audioClip;
            Debug.Log(audioSource.clip);
            audioSource.Play();
            SoundOn = false;  
        } 
    }

    void OffSound() {
        if (!SoundOn) {
            audioSource.Stop();
            SoundOn = true; 
        }
    }

    void Update()
    {
        LoudClip();
        if (rightPage.transform.eulerAngles.z < 5 && leftPage.transform.eulerAngles.z > 175) {
            textScript.SetText(BookText);
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
