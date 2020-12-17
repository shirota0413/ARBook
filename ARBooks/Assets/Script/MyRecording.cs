using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyRecording : MonoBehaviour{
    AudioClip myclip;
    AudioSource audioSource;
    string micName = "null"; //マイクデバイスの名前
    const int samplingFrequency = 44100; //サンプリング周波数
    const int maxTime_s = 30; //最大録音時間[s]
    int i = 1;
    public int num;

    bool RecordTag = true;
    private bool rbtag = true;

    public bool RecoerdButtonTag {
        get{ return rbtag; }
        set{ rbtag = value; }
    }

    bool PlayTag = true;
    private　bool pbtag = false;

    public bool PlayButtonTag {
        get{ return pbtag; }
        set{ pbtag = value; }
    }

    private bool svtag = false;
    public bool SaveButtonTag {
        get{ return svtag; }
        set{ svtag = value; }
    }

    void Start() {
        //マイクデバイスを探す
        foreach (string device in Microphone.devices) {
            Debug.Log("Name: " + device);
            //micName = "Built-in Microphone";
            micName = device;
        }
    }

    public void RecoerdButton() {
        if (RecordTag) {
            Debug.Log("recording start");
            PlayButtonTag = false;
            SaveButtonTag = false;
            // deviceName: "null" -> デフォルトのマイクを指定
            myclip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime_s, frequency: samplingFrequency);
            RecordTag = !RecordTag;
        } else if(!RecordTag) {
                if (Microphone.IsRecording(deviceName: micName) == true) {
                Debug.Log("recording stoped");
                Microphone.End(deviceName: micName);
                PlayButtonTag = true;
                SaveButtonTag = true;
            } else {
                Debug.Log("not recording");
            }
            RecordTag = !RecordTag;
        }
    }

    public void PlayButton() {
        if (PlayTag) {
            RecoerdButtonTag = false;
            SaveButtonTag = false;
            Debug.Log("play");
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = myclip;
            audioSource.Play();
            PlayTag = !PlayTag;
        } else if (!PlayTag) {
            RecoerdButtonTag = true;
            SaveButtonTag = true;
            audioSource.Stop();
            PlayTag = !PlayTag;
        }
    }

    public void SaveButton()　{
        if (i <= 17) {
            Debug.Log("save");
            SavWav.Save(i.ToString(), myclip);
            PlayButtonTag = false;
            SaveButtonTag = false;
            myclip = null;
            i += 1;
        }
    }
}