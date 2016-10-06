using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CandidateBController : MonoBehaviour{

    public string fullname;
    public string gender;
    public string birthdate;
    public string ethnicity;
    public string occupation;
    public string skills;
    public string description;

    private Transform Name;
    private Transform DOB;
    private Transform Ethinicity;
    private Transform Occupation;
    private Transform Traits;
    private Transform Skills;
    private Transform Description;
 
    void Start()
    {
        Name = transform.Find("Second Profile/Second Name");
        DOB = transform.Find("Second Profile/Second DOB");
        Ethinicity = transform.Find("Second Profile/Second Ethinicity");
        Occupation = transform.Find("Second Profile/Second Occupation");
        Skills = transform.Find("Second Profile/Second Skills");
        Description = transform.Find("Second Profile/Second Description");
    }

    void Update()
    {
        Name.GetComponent<Text>().text = fullname;
        DOB.GetComponent<Text>().text = birthdate;
        Ethinicity.GetComponent<Text>().text = ethnicity;
        Occupation.GetComponent<Text>().text = occupation;
        Skills.GetComponent<Text>().text = "Skills: " + skills;
        Description.GetComponent<Text>().text = description;
    }
}
