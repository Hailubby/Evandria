using UnityEngine;
using System.Collections;
using System;

public class ItemInteractionScript : MonoBehaviour, Assets.Scripts.Interactable {

    public void interact()
    {
        Debug.Log("This item has been interacted with!");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
