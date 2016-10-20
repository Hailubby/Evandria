using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeTheme : MonoBehaviour {

    public GameObject TopPanel;

	// Use this for initialization
	void Start () {

        // Read if light or dark theme and change colours accordingly
        GlobalConfigSettings settings = GameObject.FindObjectOfType<GlobalConfigSettings>();
        Image img =  this.TopPanel.GetComponent<Image>();
        string bgColorHex = null;
        string fontColorHex = null;

        // Get the active hex value
        foreach (Theme theme in settings.themeContainer.Themes)
        {
            if (theme.Selected)
            {
                bgColorHex = theme.BGColour;
                fontColorHex = theme.FontColour;
                break;
            }
        }

        // Set the background colour 
        Color bgColor = new Color();
        ColorUtility.TryParseHtmlString(bgColorHex, out bgColor);
        img.color = bgColor;

        // Set the font color
        Color fontColor = new Color();
        ColorUtility.TryParseHtmlString(fontColorHex, out fontColor);

        Debug.Log(TopPanel.transform.childCount);

        for (int i = 0; i < TopPanel.transform.childCount; i++)
        {
            GameObject child = TopPanel.transform.GetChild(i).gameObject;
            if (child.transform.childCount == 1 || child.transform.childCount == 2)
            {
                child.transform.GetChild(0).gameObject.GetComponent<Text>().color = fontColor;
            }
            else if (child.transform.childCount == 0)
            {
                Text targetText = child.GetComponent<Text>();
                targetText.color = fontColor;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
