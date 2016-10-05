using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationTextScript : MonoBehaviour
{

    public Text locationText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLocationText(string location)
    {
        locationText.text = location;
    }
}
