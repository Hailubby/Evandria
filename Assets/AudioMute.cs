using UnityEngine;
using System.Collections;

public class AudioMute : MonoBehaviour {

    bool isMute;

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}
