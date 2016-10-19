using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ClockTimerAnimator : MonoBehaviour {

    public Text timerText;
    public Transform hours;
    public Transform minutes;

    private float hoursToDegrees;
    private float minsToDegrees;

    private TimeSpan myTimeSpan;
    private float timer;
    private bool timeUp = false;

    // Use this for initialization
    void Start () {
        if (EvandriaUpdate.level == 1)
        {
            timer = 720f;
            myTimeSpan = new TimeSpan(0, 0, 18, 0, 0);

            hoursToDegrees = (360f / 12f) * (2f / 3f);
            minsToDegrees = (360f / 60f) * (2f / 3f);
        }
        else if (EvandriaUpdate.level == 2)
        {
            timer = 600f;
            myTimeSpan = new TimeSpan(0, 0, 15, 0, 0);

            hoursToDegrees = (360f / 12f) * (4f / 5f);
            minsToDegrees = (360f / 60f) * (4f / 5f);
        }
        else if (EvandriaUpdate.level == 3) {
            timer = 480f;
            myTimeSpan = new TimeSpan(0, 0, 12, 0, 0);

            hoursToDegrees = (360f / 12f);
            minsToDegrees = (360f / 60f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float changeInTime = Time.deltaTime;
        //update timer
        Timer(changeInTime);
        //update clock hands
        if (timer > 0) {
            Clock(changeInTime);
        }
    }

    public void Timer(float changeInTime) {
        timer -= changeInTime;

        if (timer <= 0)
        {
            timer = 0;
            if (!timeUp)
            {
                timeUp = true;
                Warp warpScript = FindObjectOfType<Warp>();
                warpScript.WarpTo(new Vector3(17.5f, 24.5f, 0), "Office");
            }
        }

        string minutes = ((int)timer / 60).ToString();
        string seconds = (timer % 60).ToString("f1");

        timerText.text = minutes + ":" + seconds;
    }

    public void Clock(float changeInTime) {
        myTimeSpan += TimeSpan.FromSeconds(changeInTime);
        //DateTime time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, (float)myTimeSpan.TotalMinutes * -hoursToDegrees);
        //minutes.localRotation = Quaternion.Euler(0f, 0f, (float)myTimeSpan.TotalSeconds * -minsToDegrees);
        if (EvandriaUpdate.level == 1)
        {
            minutes.localRotation = Quaternion.Euler(0f, 0f, (timer % 90) * minsToDegrees);
        }
        else if (EvandriaUpdate.level == 2)
        {
            minutes.localRotation = Quaternion.Euler(0f, 0f, (timer % 75) * minsToDegrees);
        }
        else if (EvandriaUpdate.level == 3)
        {
            minutes.localRotation = Quaternion.Euler(0f, 0f, (timer % 60) * minsToDegrees);
        }
        
    }
}
