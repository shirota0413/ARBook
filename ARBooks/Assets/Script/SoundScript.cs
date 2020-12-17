using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    public AudioClip[] sounds;
    AudioSource audioSource;
    int i = 0;
    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void SEPlay() {
        audioSource.clip = sounds[i%sounds.Length];
        audioSource.PlayOneShot(sounds[i%sounds.Length]);
        i++;
    }
}
