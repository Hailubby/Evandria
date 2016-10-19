using UnityEngine;
using System.Collections;

public class AmbientLight : MonoBehaviour
{

    //Global variables set from inspector, for testing/experimenting purposes.
    public static AmbientLight curController { get; private set; } 
    public static int curLightMode { get; private set; }
    public static int dayLength { get; private set; }
    public static int[] timeList { get; private set; }
    public static Color[] colorList { get; private set; }
    public static float transitionSpeed { get; private set; }
    public static float transitionSpeedDelay { get; private set; }

    //Local Variables for the Editor Inspector window
    // How fast to move through the Lerp
    public float _transitionSpeed = 0.01f;
    // How many seconds to wait before Lerping further                          
    public float _transitionSpeedDelay = 0.05f;
    // 720 seconds in level 1                   
    public int _dayLength = 720;
    // When to trigger the color switches                                                   
    public int[] _timeList = new int[] { 10, 20, 30, 40 };
    // What color to become
    // The first color is the default color, colour list must be 1 larger than time list.
    public Color[] _colorList = new Color[] { Color.white, Color.white, Color.white, Color.white, Color.white }; 

    void Start()
    {
        //Check if ambient light system has been activated somewhere else yet or not.
        if (AmbientLight.curController == null)
        { 
            if (_timeList != null && _colorList != null && _dayLength > 0)
            {
                //if (_colorList.Length != _timeList.Length + 1)
               // {
                //    Debug.LogError("Color list size must be one more than time list size! The first color is the default color, the first time is when to move to the second color!");
                //    return;
               // }
                // Ambient light controller is this script.
                AmbientLight.curController = this; 
                AmbientLight.curLightMode = 0;
                AmbientLight.dayLength = _dayLength;
                AmbientLight.timeList = _timeList;
                AmbientLight.colorList = _colorList;
                AmbientLight.transitionSpeed = _transitionSpeed;
                AmbientLight.transitionSpeedDelay = _transitionSpeedDelay;
                RenderSettings.ambientLight = _colorList[0]; // Set the default color
            }
        }
    }

    bool coloursLeft = true;
    //restart coroutine boolean.
    bool colourChanged = false; 
    void FixedUpdate()
    {
        if (AmbientLight.curController == this)
        {
            float curTime = Time.fixedTime % AmbientLight.dayLength; // The current time of day is the number of seconds since start mod the day length in seconds

            if (coloursLeft)
            { // We're still within the time list bounds
                if (curTime > AmbientLight.timeList[AmbientLight.curLightMode])
                { // The current time of day is more than the switch event
                    AmbientLight.curLightMode++; // So shift to the next light mode
                    // Set boolean to start clerp coroutine, collur change
                    colourChanged = true; 
                    if (AmbientLight.curLightMode >= AmbientLight.timeList.Length)
                    {
                        // No more times in time list/colours left, all time transitions have been done. Must wait until end of day now
                        coloursLeft = false; 
                    }
                }
            }
            if (colourChanged)
            { // Something changed our color
                colourChanged = false; // Don't restart the coroutine again
                // Stop the current transition
                StopCoroutine("CLerp");
                // Lerp colour at corresponding time transition
                StartCoroutine("CLerp", colorList[curLightMode]); 
            }
        }
    }

    IEnumerator CLerp(Color newColor)
    {
        //Debug.Log( "Start Transition to " + newColor.ToString());
        Color oldColor = RenderSettings.ambientLight; // The current colour
        for (float t = 0; t < 1 + AmbientLight.transitionSpeed; t += AmbientLight.transitionSpeed)
        {
            // Lerp current ambient light colour towards the new colour
            RenderSettings.ambientLight = Color.Lerp(oldColor, newColor, t);
            // Wait for the assigned number of seconds
            yield return new WaitForSeconds(AmbientLight.transitionSpeedDelay); 
        }
        Debug.Log ("Transition complete now " + RenderSettings.ambientLight.ToString());
    }
}