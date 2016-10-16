using UnityEngine;
using System.Collections;

/*
 * Allows an NPC to walk around randomly
 */
//[RequireComponent(typeof(CharacterController))]
public class NPCWalking : MonoBehaviour
{
    public float speed = 5;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 30;

    CharacterController controller;
    float heading;
    Vector3 targetRotation;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
        var forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(forward * speed);
    }

    /*
     * Calculates a new direction to move to.
     * This is so the interval is able to be changed at runtime, rather than using MonoBehaviour.InvokeRepeating
     */
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /*
     * Calculates a new direction for the NPC to walk
     */
    void NewHeadingRoutine()
    {
        var minimum = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var maximum = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(minimum, maximum);
        targetRotation = new Vector3(0, heading, 0);
    }
}