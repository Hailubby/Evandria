using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

// Load user settings/theme from XML file
public class LoadTheme : MonoBehaviour {

    public Toggle lightToggle;
    public Toggle darkToggle;


    // Use this for initialization
    void Start () {

        // Load toggle state based on xml file
        GlobalConfigSettings settings = GameObject.FindObjectOfType<GlobalConfigSettings>();
        lightToggle.isOn = settings.themeContainer.Themes[0].Selected;
        darkToggle.isOn = settings.themeContainer.Themes[1].Selected;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    
   public void ChangeOnToggle(){

        // Check which toggle is checked
        GlobalConfigSettings settings = GameObject.FindObjectOfType<GlobalConfigSettings>();
        settings.themeContainer.Themes[0].Selected = lightToggle.isOn;
        settings.themeContainer.Themes[1].Selected = darkToggle.isOn;

        // Write/save to XML file
        settings.themeContainer.Save(Application.dataPath + "/StreamingAssets/ThemeOptions.xml");

    }


}
