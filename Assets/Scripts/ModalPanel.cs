using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour
{
    public Button firstButton;
    public Button secondButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    // Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
    public void Choice(UnityAction firstCandidate, UnityAction secondCandidate)
    {
        modalPanelObject.SetActive(true);

        Text firstCandidateName = GameObject.Find("First Name").GetComponent<Text>();
        Text chooseFirst = GameObject.Find("Candidate1Text").GetComponent<Text>();
        Text secondCandidateName = GameObject.Find("Second Name").GetComponent<Text>();
        Text chooseSecond = GameObject.Find("Candidate2Text").GetComponent<Text>();

        chooseFirst.text = firstCandidateName.text;
        chooseSecond.text = secondCandidateName.text;

        firstButton.onClick.RemoveAllListeners();
        firstButton.onClick.AddListener(firstCandidate);
        firstButton.onClick.AddListener(ClosePanel);

        secondButton.onClick.RemoveAllListeners();
        secondButton.onClick.AddListener(secondCandidate);
        secondButton.onClick.AddListener(ClosePanel);
        
        firstButton.gameObject.SetActive(true);
        secondButton.gameObject.SetActive(true);
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}