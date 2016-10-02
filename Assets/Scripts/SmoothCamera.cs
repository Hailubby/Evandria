using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

    public Transform target;
    public float adjustScale = 0.25f;
    public float cameraSpeed = 0.1f;
    Camera myCamera;

	// Use this for initialization
	void Start () {

        myCamera = GetComponent<Camera>();


	}
	
	// Update is called once per frame
	void Update () {
        //Cause camera to scale nicely when the aspect ratio varies
        myCamera.orthographicSize = (Screen.height / 100.0f / adjustScale);
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, cameraSpeed) + new Vector3(0,0,-10);

        }
    }
}

