using UnityEngine;
using System.Collections;
using System.IO;

public class GlobalConfigSettings : MonoBehaviour {

    public ThemeContainer themeContainer;

    // Use this for initialization
    void Start () {
 
        DontDestroyOnLoad(this);

        Debug.Log(Application.dataPath + "/StreamingAssets/ThemeOptions.xml HI");
        // Load XML
        themeContainer = ThemeContainer.Load(Application.dataPath + "/StreamingAssets/ThemeOptions.xml");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
