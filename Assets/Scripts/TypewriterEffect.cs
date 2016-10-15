using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour {

    public float delay = 0.001f;
    public string fullText;
    private string currentText = "";
    public string nextText;

    private int count = 0;
    private bool contToNextScreen = false;

    //public GameObject canvas;
    //private Animator fadeToBlack;

    // Use this for initialization
    void Start() {
       // fadeToBlack = canvas.GetComponent<Animator>();
       // fadeToBlack.enabled = false;
        init(fullText);
	}

    //control k control u to uncomment
       public void init(string text)
    {
        currentText = "";
        Debug.Log("Init is called!");
        text = text.Replace("NEWLINE", "\n");
        // Pass in FULL TEXT
        StartCoroutine(ShowText(text));
    }

    // text: the full text to type out
    IEnumerator ShowText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            if (currentText.Substring(System.Math.Max(0, currentText.Length - 1)).Equals(""))
            {
                yield return new WaitForSeconds(0);
            }
            else if (currentText.Substring(System.Math.Max(0, currentText.Length - 1)).Equals(","))
            {
                yield return new WaitForSeconds(delay + 0.2f);
            }
            else if (currentText.Substring(System.Math.Max(0, currentText.Length - 1)).Equals("."))
            {
                yield return new WaitForSeconds(delay + 0.4f);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            //this.GetComponent<Text>().enabled = false;
            contToNextScreen = true;
            count = count + 1;
        }
        if (Input.GetKeyDown("n"))
        {
            // Return to main menu
            SceneManager.LoadScene(0);
        }
       if (contToNextScreen & count != 2)
        {
            contToNextScreen = false;
            init(nextText);
        }
       if (contToNextScreen & count == 2)
        {
            // Trigger animation here 
            contToNextScreen = false;
            Debug.Log("THE GAME WILL NOW BEGIN");
            SceneManager.LoadScene(2);
        }
    }
}
