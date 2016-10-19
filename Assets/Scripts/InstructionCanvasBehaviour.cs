using UnityEngine;
using System.Collections;

public class InstructionCanvasBehaviour : MonoBehaviour
{

    public GameObject instructionCanvas;

    // Use this for initialization
    void Start()
    {

        Debug.Log("Current level is: " + EvandriaUpdate.level);
        if (EvandriaUpdate.level == 1)
        {
            instructionCanvas.SetActive(true);
        }
        else
        {
            instructionCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
