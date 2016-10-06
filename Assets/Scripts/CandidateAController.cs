using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CandidateAController : MonoBehaviour{

    public string fullname;
    public string birthdate;
    public string ethnicity;
    public string occupation;
    public string skills;
    public string description;

    private Transform Name;
    private Transform DOB;
    private Transform Ethinicity;
    private Transform Occupation;
    private Transform Skills;
    private Transform Description;

    void Start() {
        Name = transform.Find("First Profile/First Name");
        DOB = transform.Find("First Profile/First DOB");
        Ethinicity = transform.Find("First Profile/First Ethinicity");
        Occupation = transform.Find("First Profile/First Occupation");
        Skills = transform.Find("First Profile/First Skills");
        Description = transform.Find("First Profile/First Description");
    }

    void Update() {
        Name.GetComponent<Text>().text = fullname;
        DOB.GetComponent<Text>().text = birthdate;
        Ethinicity.GetComponent<Text>().text = ethnicity;
        Occupation.GetComponent<Text>().text = occupation;
        Skills.GetComponent<Text>().text = "Skills: " + skills;
        Description.GetComponent<Text>().text = description;
    }
}
