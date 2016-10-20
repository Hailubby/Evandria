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
        stopPlayerMovement = true;
        RunDialogue();

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
        node_text.GetComponentInChildren<Text>().text = "Hello!";

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
