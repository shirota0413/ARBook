using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SEの再生をするクラス
public class Sound : MonoBehaviour {

    public AudioClip[] sounds;
    AudioSource audioSource;
    int i = 0;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void SEPlay() {
        audioSource.clip = sounds[i%sounds.Length];
        audioSource.PlayOneShot(sounds[i%sounds.Length]);
        i++;
    }
}
