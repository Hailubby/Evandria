﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CandidateAController : MonoBehaviour{

    public string fullname;
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
    public Sprite sprite;

    private string traitString;

    private Transform ImagePic;
    private Transform Name;
    private Transform DOB;
    private Transform Ethinicity;
    private Transform Occupation;
    private Transform Traits;
    private Transform Skills;
    private Transform Description;

    void Start() {
        ImagePic = transform.Find("First Profile/First Image");
        Name = transform.Find("First Profile/First Name");
        DOB = transform.Find("First Profile/First DOB");
        Ethinicity = transform.Find("First Profile/First Ethinicity");
        Occupation = transform.Find("First Profile/First Occupation");
        Skills = transform.Find("First Profile/First Skills");
        Description = transform.Find("First Profile/First Description");
        Traits = transform.Find("First Profile/First Traits");

    }

    void Update() {
        ImagePic.GetComponent<Image>().sprite = sprite;
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
