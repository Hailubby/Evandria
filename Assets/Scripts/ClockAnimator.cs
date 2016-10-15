using UnityEngine;
using System.Collections;
using System;

public class ClockAnimator : MonoBehaviour {

    public Transform hours;
    public Transform minutes;
    //public Transform seconds;

    private const float hoursToDegrees = (360f / 12f)*(2f/3f);
    private const float minsToDegrees = (360f / 60f)*(2f/3f);
    // const float secsToDegrees = 360f / 60f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        DateTime time = DateTime.Now;
        hours.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -hoursToDegrees);
        minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -minsToDegrees);
        //seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secsToDegrees);
    }
}
