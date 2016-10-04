using UnityEngine;
using System.Collections;
using DialogueTree;
using UnityEngine.UI;

public class NpcInteraction : MonoBehaviour, Assets.Scripts.Interactable
{
    private Dialogue dialogue;

    private GameObject dialogue_window;
    private GameObject player_name;
    private GameObject npc_name;
    private GameObject node_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;

    private int selected_option = -2;

    //NPC dialogue
    public string DialogueDataFilePath;
    //Prefab being used to instantiate a new window
    public GameObject DialogueWindowPrefab;

    //public MovementScript player;

    public void interact()
    {
        Debug.Log("This NPC has been interacted with!");
        RunDialogue();
    }

    // Use this for initialization
    void Start () {
        dialogue = Dialogue.LoadDialogue("Assets/DialogueTrees/" + DialogueDataFilePath);

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

        npc_name.SetActive(false);
        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        dialogue_window.SetActive(false);
    }

    public void RunDialogue() {
        StartCoroutine(run());
    }

    public void SetSelectedOption(int x) {
        selected_option = x;
    }

    public IEnumerator WaitForKeyDown() {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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

    public IEnumerator run() {
        dialogue_window.SetActive(true);

        //create an indexer, set it to 0 - the dialogues starting node
        int node_id = 0;

        //while the next node is not an exit node, traverse the dialogue tree 
        //based on the user's input
        while (node_id != -1) {
            node_text.GetComponentInChildren<Text>().text = dialogue.Nodes[node_id].Text;

            yield return StartCoroutine(WaitForKeyDown());

            display_node(dialogue.Nodes[node_id]);
            selected_option = -2;
            while (selected_option == -2) {
                yield return new WaitForSeconds(0.25f);
            }

            node_id = selected_option;

            option_1.SetActive(false);
            option_2.SetActive(false);
            option_3.SetActive(false);
            node_text.SetActive(true);
        }
        //player.canMove = true;
        dialogue_window.SetActive(false);
    }

    private void display_node(DialogueNode node) {
        //Debug.Log("TEXT IN NODE IS: " + node.Text);
        //node_text.GetComponentInChildren<Text>().text = node.Text;
        node_text.SetActive(false);

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        for (int i = 0; i < node.Options.Count; i++) {
            switch (i) {
                case 0:
                    set_option_button(option_1, node.Options[i]);
                    break;
                case 1:
                    set_option_button(option_2, node.Options[i]);
                    break;
                case 2:
                    set_option_button(option_3, node.Options[i]);
                    break;
            }
        }
    }

    private void set_option_button(GameObject button, DialogueOption opt) {
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = opt.Text;
        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(opt.DestinationNodeID); });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
