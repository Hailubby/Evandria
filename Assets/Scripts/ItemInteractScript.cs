using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

[System.Serializable]
public class ItemInteractScript : MonoBehaviour, Assets.Scripts.Interactable
{
    public Clue clue;
    public Journal journal;

    public GameObject textBox;
    public MovementScript player;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public string itemName;
    public string itemOwner;
    public string itemDesc;

    public int currentLine;
    public int endLine;

    bool isActive;
    bool interacted = false;
    public bool stopPlayerMovement;

    public void interact()
    {
        // Checks if the item has already been interacted with.
        if (interacted)
        {
            Debug.Log("This item has ALREADY been interacted with! no more interaction pls");

        } else
        {
            Debug.Log("An item has been interacted with!");

            // Textbox pops up upon interaction
            stopPlayerMovement = true;
            EnableTextBox();
            isActive = true;
            interacted = true;

            //Checks if the item is relevant to the investigation or not. If it is, it will add to the journal
            if (!itemOwner.Equals("Dummy"))
            {
                journal.AddClue(clue);
            }
            
        }
    }

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<MovementScript>();
        journal = FindObjectOfType<Journal>();
        
        
        // Splits text file containing description of item
        if (textFile != null)
        {
            textLines = Regex.Split(textFile.text, "\r\n");

            // Assigns the item name identification, and the owner from the text file, and description
            itemName = textLines[0];
            itemOwner = textLines[1];
            itemDesc = textLines[3];

            // Generates a clue object which holds all the necessary information of the specified clue
            clue = new Clue(itemName, itemOwner, itemDesc);
            currentLine = 3;
        }

        if (endLine == 0)
        {
            endLine = textLines.Length - 1;
        }

        // Default popup of text is inactive until interaction with item
        if (!isActive)
        {
            textBox.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        // If no dialog popup is active, then don't continue
        if (!isActive)
        {
            return;
        }

        // Reads the first line of the text file
        theText.text = textLines[currentLine];

        // Goes to next line of desciption upon keyboard or mouse input
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            currentLine += 1;
        }

        // Once the entire text has been read through, can now close the dialog popup
        if (currentLine > endLine)
        {
            DisableTextBox();
            isActive = false;
        }
    }

    //Enable the popup to become visible
    public void EnableTextBox()
    {
        textBox.SetActive(true);

        // Prevents the player from moving when pop up is visible and prevents ability to cast E
        if (stopPlayerMovement)
        {
            player.DisableMovement();
            player.GetComponent<InteractionScript>().interacting = true;
        }

    }

    // Disables the popup visibility
    public void DisableTextBox()
    {
        textBox.SetActive(false);

        // Re-enables the player to move again and ability to cast E
        player.EnableMovement();
        player.GetComponent<InteractionScript>().interacting = false;
    }

    // Gets the current item's name
    public string GetItemName()
    {
        return itemName;
    }
}
