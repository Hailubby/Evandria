using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SetAudioLevels : MonoBehaviour
{
    public AudioMixer mainMixer;                    //Used to hold a reference to the AudioMixer mainMixer


    //Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
    public void SetMusicLevel(float musicLvl)
    {
        //       mainMixer.SetFloat("musicVol", LinearToDecibel(musicLvl));
        //musicLvl = (float)Math.Pow(musicLvl, 2.72);
       Debug.Log(musicLvl);
        mainMixer.SetFloat("musicVol", musicLvl);
    }

    //Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
    public void SetSfxLevel(float sfxLevel)
    {
        mainMixer.SetFloat("sfxVol", sfxLevel);
    }

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }
}
