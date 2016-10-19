using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CandidateBController : MonoBehaviour{

    public string fullname;
    public string gender;
    public string birthdate;
    public string ethnicity;
    public string occupation;
    public string skills;
    public string description;
    public List<string> traits;
    public string moral;
    public string goodArray;
    public string badArray;
    public string houseSize;

    private string traitString;

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
        Traits = transform.Find("Second Profile/Second Traits");
    }

    void Update()
    {
        Name.GetComponent<Text>().text = fullname;
        DOB.GetComponent<Text>().text = birthdate;
        Ethinicity.GetComponent<Text>().text = ethnicity;
        Occupation.GetComponent<Text>().text = occupation;
        Skills.GetComponent<Text>().text = "Skills: " + skills;
        Description.GetComponent<Text>().text = description;

        traitString = "";
        foreach(string trait in traits)
        {
            traitString += trait + ", ";
        }
        Traits.GetComponent<Text>().text = traitString;
    }
}
