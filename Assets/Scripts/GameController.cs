using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
