using UnityEngine;
using System.Collections;
using System;

public class LaptopScript : MonoBehaviour, Assets.Scripts.Interactable
{
    public MovementScript player;
    public GameObject decisionCanvas;

    public void interact()
    {
        decisionCanvas.SetActive(true);
        player.DisableMovement();
    }
}
