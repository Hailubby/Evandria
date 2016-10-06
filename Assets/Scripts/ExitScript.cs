using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

    public bool isActive;
    public GameObject canvas;

	// Use this for initialization
	void Start () {
        canvas.SetActive(false);
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Q))
        {
            if(!isActive)
            {
                canvas.SetActive(true);
                isActive = true;
            }
            else
            {
                canvas.SetActive(false);
                isActive = false;
            }
        }
	}
}
