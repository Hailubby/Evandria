using UnityEngine;
using System.Collections;

public class NPCAudio : MonoBehaviour {

    public void Play()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void Stop()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Pause();
    }
}
