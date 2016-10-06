using UnityEngine;
using System.Collections;

public class TextReader : MonoBehaviour {

    public TextAsset textFile;
    public string outcomeText;

    

	// Use this for initialization
	void Start () {
	    if (textFile != null)
        {
            outcomeText = textFile.text;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
