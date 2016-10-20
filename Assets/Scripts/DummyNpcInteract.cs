using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DummyNpcInteract : MonoBehaviour, Assets.Scripts.Interactable
{

    private GameObject dialogue_window;
    private GameObject player_name;
    private GameObject npc_name;
    private GameObject node_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;

    //Prefab being used to instantiate a new window
    public GameObject DialogueWindowPrefab;

    public MovementScript player;
    public bool stopPlayerMovement;

    public void interact()

    {
        AssignText();
        stopPlayerMovement = true;
        RunDialogue();

    }

    public void AssignText() {
        System.Random rnd = new System.Random();
        int random = rnd.Next(10);

        switch (random)
        {
            case 0:
                node_text.GetComponentInChildren<Text>().text = "I wish I could go to Evandria.";
                break;
            case 1:
                node_text.GetComponentInChildren<Text>().text = "Hey Alex! Haven't seen you in a while.";
                break;
            case 2:
                node_text.GetComponentInChildren<Text>().text = "I hear Evandria is great this time of year!";
                break;
            case 3:
                node_text.GetComponentInChildren<Text>().text = "People tell me Evandrian years are 420 days long!";
                break;
            case 4:
                node_text.GetComponentInChildren<Text>().text = "My cousin's application to Evandria got rejected, could you put in a good word for him please?";
                break;
            case 5:
                //Suitable for male and female npcs
                node_text.GetComponentInChildren<Text>().text = "My wife got accepted to go to Evandria! She left me all alone, I'm so lonely.";
                break;
            case 6:
                node_text.GetComponentInChildren<Text>().text = "Should I apply for Evandria? I don't know if I'll be suitable or not.";
                break;
            case 7:
                node_text.GetComponentInChildren<Text>().text = "Can I take my dog with me to Evandria? I can't survive without him!";
                break;
            case 8:
                node_text.GetComponentInChildren<Text>().text = "I'm late for work. Have to hurry!";
                break;
            case 9:
                node_text.GetComponentInChildren<Text>().text = "I used to be an investigator just like you. But then I took a bribe and was fired.";
                break;
            default:
                node_text.GetComponentInChildren<Text>().text = "Something feels off today...";
                break;
        }
    }

    public void RunDialogue()
    {
        StartCoroutine(run());
    }

    public IEnumerator WaitForKeyDown()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                break;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                break;
            }
            else
            {
                yield return null;
            }
        }
        yield return null;
    }

    public IEnumerator run()
    {
        dialogue_window.SetActive(true);

        if (stopPlayerMovement)
        {
            player.DisableMovement();
            player.GetComponent<InteractionScript>().interacting = true;
        }

        yield return StartCoroutine(WaitForKeyDown());

        //Reenable player movement
        player.EnableMovement();
        player.GetComponent<InteractionScript>().interacting = false;
        dialogue_window.SetActive(false);
    }


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<MovementScript>();

        var canvas = GameObject.Find("Canvas");

        dialogue_window = Instantiate<GameObject>(DialogueWindowPrefab);
        dialogue_window.transform.SetParent(canvas.transform, false);

        dialogue_window.SetActive(true);

        RectTransform dialogue_window_transform = (RectTransform)dialogue_window.transform;
        dialogue_window_transform.localPosition = new Vector3(0, -170, 0);

        node_text = GameObject.Find("NPC_Response");
        option_1 = GameObject.Find("Button_Option1");
        option_2 = GameObject.Find("Button_Option2");
        option_3 = GameObject.Find("Button_Option3");
        player_name = GameObject.Find("Player_Name");
        npc_name = GameObject.Find("NPC_Name");

        npc_name.GetComponentInChildren<Text>().text = "Townsperson";

        

        player_name.SetActive(false);
        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        dialogue_window.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
