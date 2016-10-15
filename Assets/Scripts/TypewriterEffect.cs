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

    private bool isFinished = false;

    // Use this for initialization
    void Start() {
        init(fullText);
	}

    //control k control u to uncomment
       public void init(string text)
    {
        currentText = "";
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
                yield return new WaitForSeconds(delay + 0.1f);
            }
            else if (currentText.Substring(System.Math.Max(0, currentText.Length - 1)).Equals("."))
            {
                yield return new WaitForSeconds(delay + 0.2f);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
        isFinished = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("y") && isFinished)
        {
            contToNextScreen = true;
            isFinished = false;
            count = count + 1;
        }
        if (Input.GetKeyDown("n") && isFinished)
        {
            // Return to main menu
            SceneManager.LoadScene(0);
            isFinished = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
       if (contToNextScreen & count != 2)
        {
            contToNextScreen = false;
            init(nextText);
        }
       if (contToNextScreen & count == 2)
        {
            contToNextScreen = false;
            SceneManager.LoadScene(2);
        }
    }
}
