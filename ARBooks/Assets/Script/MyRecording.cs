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
    bool PlayTag = true;

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
            // deviceName: "null" -> デフォルトのマイクを指定
            myclip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime_s, frequency: samplingFrequency);
            RecordTag = !RecordTag;
        } else if(!RecordTag) {
                if (Microphone.IsRecording(deviceName: micName) == true) {
                Debug.Log("recording stoped");
                Microphone.End(deviceName: micName);
            } else {
                Debug.Log("not recording");
            }
            RecordTag = !RecordTag;
        }
    }

    // public void StartButton() {
    //     Debug.Log("recording start");
    //     // deviceName: "null" -> デフォルトのマイクを指定
    //     myclip = Microphone.Start(deviceName: micName, loop: false, lengthSec: maxTime_s, frequency: samplingFrequency);
    // }

    // public void EndButton() {
    //     if (Microphone.IsRecording(deviceName: micName) == true) {
    //         Debug.Log("recording stoped");
    //         Microphone.End(deviceName: micName);
    //     } else {
    //         Debug.Log("not recording");
    //     }
    // }

    public void PlayButton() {
        if (PlayTag) {
            Debug.Log("play");
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = myclip;
            Debug.Log(myclip);
            audioSource.Play();
            PlayTag = !PlayTag;
        } else if (!PlayTag) {
            audioSource.Stop();
            PlayTag = !PlayTag;
        }
    }

    public void SaveButton()　{
        if (i <= 17) {
            Debug.Log("save");
            SavWav.Save(i.ToString(), myclip);
            i += 1;
        }


        //SavWav.Save("mic_" + DateTime.Now.ToString("yyyyMMddhhmmss"), myclip);
    }
}