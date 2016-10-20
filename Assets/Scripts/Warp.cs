using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Warp : MonoBehaviour
{

    public GameObject WarpUI;
    public GameObject Content;
    public GameObject buttonPrefab;
    public MovementScript player;
    public InteractionScript interactor;
    Collider2D other;
    Locations locations;
    ScreenFader sf;

    public bool isGenerated = false;
    public bool isNotRegen = true;

    void Start()
    {
        WarpUI.SetActive(false);
        GameObject player = GameObject.Find("Player");
        locations = player.GetComponent<Locations>();
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        this.other = player.GetComponent<Collider2D>();
        this.player = player.GetComponent<MovementScript>();
        this.interactor = player.GetComponent<InteractionScript>();
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        this.other = other;
        isGenerated = other.GetComponent<Locations>().isGenerated;
        OpenTheGui();
    }

    void OpenTheGui()
    {
        player.DisableMovement();
        interactor.interacting = true;
        if (!isGenerated)
        {
            //Create the menu from stored locations
            CandidateAssociations cAssociations = FindObjectOfType<CandidateAssociations>();
            for(int i = 0; i < cAssociations.locations.Count; i++)
            {
                Locations.Location loco = (Locations.Location) cAssociations.locations[0];
                // To instantiate
                GameObject newButton = (GameObject)Instantiate(buttonPrefab);
                newButton.transform.SetParent(Content.transform, false);
                newButton.transform.localScale = new Vector3(1, 1, 1);
                if (i == 0)
                {
                    if (isNotRegen)
                    {
                        newButton.name = "Office";
                        newButton.GetComponentInChildren<Text>().text = "Office";
                        isNotRegen = false;
                    }
                    else
                    {
                        GameObject.Destroy(newButton);
                    }
                }

                else if (i == 1)
                {
                    newButton.name = "Town Square";
                    newButton.GetComponentInChildren<Text>().text = "Town Square";
                    loco = (Locations.Location) cAssociations.locations[1];
                }
                
                else if (i == 2)
                {
                    newButton.name = cAssociations.CandidateAName;
                    newButton.GetComponentInChildren<Text>().text = cAssociations.CandidateAName + "'s House";
                    loco = cAssociations.houseA;
                }
                else
                {
                    newButton.name = cAssociations.CandidateBName;
                    newButton.GetComponentInChildren<Text>().text = cAssociations.CandidateBName + "'s House";
                    loco = cAssociations.houseB;
                }
                Button thisButton = newButton.GetComponent<Button>();

                Vector3 capturedLocation = loco.entrance;
                thisButton.onClick.AddListener(() => {
                    StartCoroutine(WarpTo(capturedLocation, thisButton.GetComponentInChildren<Text>().text));
                    WarpUI.SetActive(false);
                    player.EnableMovement();
                    interactor.interacting = false;
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