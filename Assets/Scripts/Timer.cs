using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = 90f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = 0;
            //Go back to office here
        }

        string minutes = ((int)timer / 60).ToString();
        string seconds = (timer % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;
	}

    
}
