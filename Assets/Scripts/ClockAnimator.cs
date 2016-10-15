using UnityEngine;
using System.Collections;
using System;

public class ClockAnimator : MonoBehaviour {

    public Transform hours;
    public Transform minutes;
    public int level;

    private float hoursToDegrees;
    private float minsToDegrees;

    private TimeSpan myTimeSpan;

    // Use this for initialization
    void Start () {
        if (level == 1)
        {
            myTimeSpan = new TimeSpan(0, 0, 18, 0, 0);

            hoursToDegrees = (360f / 12f) * (2f / 3f);
            minsToDegrees = (360f / 60f) * (2f / 3f);
        }
        else if (level == 2)
        {
            myTimeSpan = new TimeSpan(0, 0, 15, 0, 0);

            hoursToDegrees = (360f / 12f) * (4f / 5f);
            minsToDegrees = (360f / 60f) * (4f / 5f);
        }
        else if (level == 3) {
            myTimeSpan = new TimeSpan(0, 0, 12, 0, 0);

            hoursToDegrees = (360f / 12f);
            minsToDegrees = (360f / 60f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //TimeSpan timespan = DateTime.Now.TimeOfDay;
        myTimeSpan += TimeSpan.FromSeconds(Time.deltaTime);
        DateTime time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, (float)myTimeSpan.TotalMinutes * -hoursToDegrees);
        minutes.localRotation = Quaternion.Euler(0f, 0f, (float)myTimeSpan.TotalSeconds * -minsToDegrees);
    }
}
