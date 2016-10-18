using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeTheme : MonoBehaviour {

    public GameObject TopPanel;

	// Use this for initialization
	void Start () {

        // Read if light or dark theme and change colours accordingly
        GlobalConfigSettings settings = GameObject.FindObjectOfType<GlobalConfigSettings>();
        Image img =  TopPanel.GetComponent<Image>();
        string bgColorHex = null;

        // Get the active hex value
        foreach (Theme theme in settings.themeContainer.Themes)
        {
            if (theme.Selected)
            {
                bgColorHex = theme.BGColour;
                break;
            }
        }

        Debug.Log(bgColorHex);
        Color navy = new Color();
        ColorUtility.TryParseHtmlString(bgColorHex, out navy);
        Debug.Log(navy);
        img.color = navy;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
