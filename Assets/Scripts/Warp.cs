using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Warp : MonoBehaviour
{

    public GameObject WarpUI;
    public GameObject Content;
    public GameObject buttonPrefab;
    Collider2D other;
    Locations locations;
    ScreenFader sf;

    private bool isGenerated = false;

    void Start()
    {
        WarpUI.SetActive(false);
        GameObject player = GameObject.Find("Player");
        locations = player.GetComponent<Locations>();
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        this.other = player.GetComponent<Collider2D>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        this.other = other;
        isGenerated = other.GetComponent<Locations>().isGenerated;
        OpenTheGui();
    }

    void OpenTheGui()
    {
        if (!isGenerated)
        {
            //Create the menu from locations
            foreach (Locations.Location loco in locations.locations)
            {
                // To instantiate
                GameObject newButton = (GameObject)Instantiate(buttonPrefab);
                newButton.transform.SetParent(Content.transform, false);
                newButton.transform.localScale = new Vector3(1, 1, 1);
                newButton.name = loco.name;

                newButton.GetComponentInChildren<Text>().text = loco.name;
                Button thisButton = newButton.GetComponent<Button>();


                Vector3 capturedLocation = loco.entrance;
                string capturedString = loco.name;
                thisButton.onClick.AddListener(() => {
                    StartCoroutine(WarpTo(capturedLocation, capturedString));
                    WarpUI.SetActive(false);
                });
            }
            other.GetComponent<Locations>().isGenerated = true;
        }

        // Open up the GUI
        WarpUI.SetActive(true);

    }

    public IEnumerator WarpTo(Vector3 location, string locationName)

    {
        // Start fading to black
        yield return StartCoroutine(sf.FadeToBlack());

        // Warping begins
        Debug.Log("Going to X: " + location.x + " and Y: " + location.y);
        other.gameObject.transform.position = location;
        Camera.main.transform.position = location;
        LocationTextScript script = GameObject.FindObjectOfType<LocationTextScript>();
        script.UpdateLocationText(locationName);

        // Start fading to clear
        yield return StartCoroutine(sf.FadeToClear());
    }

}