using UnityEngine;
using System.Collections;
using System;

public class ClockAnimator : MonoBehaviour {

    public Transform hours;
    public Transform minutes;

    private const float hoursToDegrees = (360f / 12f)*(2f/3f);
    private const float minsToDegrees = (360f / 60f)*(2f/3f);

    private TimeSpan myTimeSpan = new TimeSpan(0, 0, 18, 0, 0);

    // Use this for initialization
    void Start () {
	
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
