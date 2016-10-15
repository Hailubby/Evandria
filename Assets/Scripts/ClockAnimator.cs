using UnityEngine;
using System.Collections;
using System;

public class ClockAnimator : MonoBehaviour {

    public Transform hours;
    public Transform minutes;
    public Transform seconds;

    public bool analog;

    private const float hoursToDegrees = 360f / 12f;
    private const float minsToDegrees = 360f / 60f;
    private const float secsToDegrees = 360f / 60f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (analog)
        {
            TimeSpan timespan = DateTime.Now.TimeOfDay;
            hours.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minsToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secsToDegrees);
        }
        else
        {
            DateTime time = DateTime.Now;
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minsToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secsToDegrees);
        }
        
	}
}
