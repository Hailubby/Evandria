using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PanelLightingColour : MonoBehaviour
{

    public GameObject lightingPanel;
    public GameObject currentLocation;

    public static int curLightMode { get; private set; }
    public static int dayLength { get; private set; }
    public static int[] timeList { get; private set; }
    public static Color[] colorList { get; private set; }
    public static float transitionSpeed { get; private set; }
    public static float transitionSpeedDelay { get; private set; }


    // How fast to move through the colour change
    public float _transitionSpeed = 0.01f;
    // How many seconds to wait before Lerping further                          
    public float _transitionSpeedDelay = 0.05f;                  
    public int _dayLength;
    // When to trigger the color changes                                                  
    public int[] _timeList;
    // What color to become
    // The first color is the default color, colour list must be 1 larger than time list.
    public Color[] _colorList = new Color[] { Color.white, Color.white, Color.white, Color.white, Color.white };

    private Image img;
    private TimeSpan myTimeSpan;

    // Use this for initialization
    void Start()
    {
        if (EvandriaUpdate.level == 1)
        {
            _dayLength = 720;
            _timeList = new int[] { 270, 450, 540, 630 };
        }
        else if (EvandriaUpdate.level == 2)
        {
            _dayLength = 600;
            _timeList = new int[] { 225, 375, 450, 525 };
        }
        else if (EvandriaUpdate.level == 3)
        {
            _dayLength = 480;
            _timeList = new int[] { 180, 300, 360, 420 };
        }

        myTimeSpan = new TimeSpan(0, 0, 0, 0, 0);
        img = lightingPanel.GetComponent<Image>();
        img.color = new Color32(0xFF, 0x00, 0x00, 0x2F);

        if (_timeList != null && _colorList != null && _dayLength > 0)
        {
            PanelLightingColour.curLightMode = 0;
            PanelLightingColour.dayLength = _dayLength;
            PanelLightingColour.timeList = _timeList;
            PanelLightingColour.colorList = _colorList;
            PanelLightingColour.transitionSpeed = _transitionSpeed;
            PanelLightingColour.transitionSpeedDelay = _transitionSpeedDelay;
            img.color = _colorList[0]; // Set the default color
        }

        //Debug.Log("CURRENT LOCATION IS: " + currentLocation.GetComponent<Text>().text);

        if (currentLocation.GetComponent<Text>().text.Equals("Town Square"))
        {
            lightingPanel.SetActive(true);
        }
        else {
            lightingPanel.SetActive(false);
        }
    }


    bool coloursLeft = true;
    //restart coroutine boolean.
    bool colourChanged = false;
    void FixedUpdate()
    {
        if (currentLocation.GetComponent<Text>().text.Equals("Town Square"))
        {
            lightingPanel.SetActive(true);
        }
        else
        {
            lightingPanel.SetActive(false);
        }

        myTimeSpan += TimeSpan.FromSeconds(Time.deltaTime);
        float curTime = (float)myTimeSpan.TotalSeconds % PanelLightingColour.dayLength;
        //float curTime = Time.fixedTime % PanelLightingColour.dayLength; // The current time of day is the number of seconds since start mod the day length in seconds

        if (coloursLeft)
        { // We're still within the time list bounds
            if (curTime > PanelLightingColour.timeList[PanelLightingColour.curLightMode])
            { // The current time of day is more than the time for colour to change
                // Shift to the next light mode
                PanelLightingColour.curLightMode++;
                // Set boolean to start clerp coroutine, colour change                             
                colourChanged = true;
                if (PanelLightingColour.curLightMode >= PanelLightingColour.timeList.Length)
                {
                    // No more times in time list/colours left, all time transitions have been done. Must wait until end of day now
                    coloursLeft = false;
                }
            }
        }
        if (colourChanged)
        { 
            colourChanged = false; 
            //stop current coroutine
            StopCoroutine("CLerp");
            // Lerp colour at corresponding time transition
            StartCoroutine("CLerp", colorList[curLightMode]);
        }
    }

    IEnumerator CLerp(Color newColor)
    {
        //Debug.Log( "Start Transition to " + newColor.ToString());
        Color oldColor = img.color; // The current colour
        for (float t = 0; t < 1 + PanelLightingColour.transitionSpeed; t += PanelLightingColour.transitionSpeed)
        {
            // Lerp current panel colour to new colour
            img.color = Color.Lerp(oldColor, newColor, t);
            // Wait for the assigned number of seconds
            yield return new WaitForSeconds(AmbientLight.transitionSpeedDelay);
        }
        Debug.Log("Transition complete now " + img.color.ToString());
    }

}
