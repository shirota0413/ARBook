using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsTransition : MonoBehaviour
{
    public GameObject leftPage;
    public GameObject rightPage;

    GameObject textPanel;
    BookTextScript textScript;
    public string BookText;

    public AudioClip sound1;
    AudioSource audioSource;
    GameObject audioSourceObject;
    bool SoundOn = true;

    void Start() {
        textPanel = GameObject.Find("Canvas/TextPanel/Text");
        textScript = textPanel.GetComponent<BookTextScript>();
        audioSourceObject = GameObject.Find("audioSourceObject");
        audioSource = audioSourceObject.GetComponent<AudioSource>();
    }

    void OnSound() {
        if (SoundOn) {
            audioSource.clip = sound1;
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
