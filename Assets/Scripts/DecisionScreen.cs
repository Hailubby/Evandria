using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DecisionScreen : MonoBehaviour {
    private ModalPanel modalPanel;

    private UnityAction firstCandidate;
    private UnityAction secondCandidate;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();

        firstCandidate = new UnityAction(firstChoice);
        secondCandidate = new UnityAction(secondChoice);
    }

    public void decision ()
    {
        modalPanel.Choice(firstCandidate, secondCandidate);
    }

    public void firstChoice ()
    {
        Text firstAccept = GameObject.Find("First Accept").GetComponent<Text>();
        Color firstAcceptColor = firstAccept.color;
        firstAcceptColor.a = 1;
        firstAccept.color = firstAcceptColor;

        Text secondReject = GameObject.Find("Second Reject").GetComponent<Text>();
        Color secondRejectColor = secondReject.color;
        secondRejectColor.a = 1;
        secondReject.color = secondRejectColor;

        Text firstName = GameObject.Find("First Name").GetComponent<Text>();
        string firstCandidateName = firstName.text;
        FindObjectOfType<EvandriaUpdate>().DecisionMade(firstCandidateName);

    }

    public void secondChoice ()
    {
        Text secondAccept = GameObject.Find("Second Accept").GetComponent<Text>();
        Color secondAcceptColor = secondAccept.color;
        secondAcceptColor.a = 1;
        secondAccept.color = secondAcceptColor;

        Text firstReject = GameObject.Find("First Reject").GetComponent<Text>();
        Color firstRejectColor = firstReject.color;
        firstRejectColor.a = 1;
        firstReject.color = firstRejectColor;

        Text secondName = GameObject.Find("Second Name").GetComponent<Text>();
        string secondCandidateName = secondName.text;
        FindObjectOfType<EvandriaUpdate>().DecisionMade(secondCandidateName);
    }
}
