using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ClockTimerAnimator : MonoBehaviour {

    public Text timerText;
    public Transform hours;
    public Transform minutes;
    public int level;

    private float hoursToDegrees;
    private float minsToDegrees;

    private TimeSpan myTimeSpan;
    private float timer;

    // Use this for initialization
    void Start () {
        if (level == 1)
        {
            timer = 720f;
            myTimeSpan = new TimeSpan(0, 0, 18, 0, 0);

            hoursToDegrees = (360f / 12f) * (2f / 3f);
            minsToDegrees = (360f / 60f) * (2f / 3f);
        }
        else if (level == 2)
        {
            timer = 600f;
            myTimeSpan = new TimeSpan(0, 0, 15, 0, 0);

            hoursToDegrees = (360f / 12f) * (4f / 5f);
            minsToDegrees = (360f / 60f) * (4f / 5f);
        }
        else if (level == 3) {
            timer = 480f;
            myTimeSpan = new TimeSpan(0, 0, 12, 0, 0);

            hoursToDegrees = (360f / 12f);
            minsToDegrees = (360f / 60f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //update timer
        Timer();
        //update clock hands
        if (timer > 0) {
            Clock();
        }
    }

    public void Timer() {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            //Go back to office here
        }

        string minutes = ((int)timer / 60).ToString();
        string seconds = (timer % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;
    }

    public void Clock() {
        myTimeSpan += TimeSpan.FromSeconds(Time.deltaTime);
        DateTime time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, (float)myTimeSpan.TotalMinutes * -hoursToDegrees);
        minutes.localRotation = Quaternion.Euler(0f, 0f, (float)myTimeSpan.TotalSeconds * -minsToDegrees);
    }
}
