using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyRecording : MonoBehaviour{
    AudioClip myclip;
    AudioSource audioSource;
    //マイクデバイスの名前
    string micName = "null"; 
    //サンプリング周波数
    const int samplingFrequency = 44100;
    //最大録音時間[s]
    const int maxTime_s = 30; 
    int pageCount = 1;
    public int num;

    bool recordTag = true;
    private bool rbtag = true;

    public bool RecoerdButtonTag {
        get{ return rbtag; }
        set{ rbtag = value; }
    }

    bool playTag = true;
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

    //録音を開始する
    public void RecoerdButton() {
        if (recordTag) {
            Debug.Log("recording start");
            PlayButtonTag = false;
            SaveButtonTag = false;
            myclip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime_s, frequency: samplingFrequency);
            recordTag = !recordTag;
        } else if(!recordTag) {
                if (Microphone.IsRecording(deviceName: micName) == true) {
                Debug.Log("recording stoped");
                Microphone.End(deviceName: micName);
                PlayButtonTag = true;
                SaveButtonTag = true;
            } else {
                Debug.Log("not recording");
            }
            recordTag = !recordTag;
        }
    }

    //録音したデータを再生する．
    public void PlayButton() {
        if (playTag) {
            RecoerdButtonTag = false;
            SaveButtonTag = false;
            Debug.Log("play");
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = myclip;
            audioSource.Play();
            playTag = !playTag;
        } else if (!playTag) {
            RecoerdButtonTag = true;
            SaveButtonTag = true;
            audioSource.Stop();
            playTag = !playTag;
        }
    }

    //saveする
    public void SaveButton()　{
        if (pageCount <= 17) {
            Debug.Log("save");
            SavWav.Save(pageCount.ToString(), myclip);
            PlayButtonTag = false;
            SaveButtonTag = false;
            myclip = null;
            pageCount += 1;
        }
    }
}