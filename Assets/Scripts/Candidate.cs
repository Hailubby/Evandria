﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Candidate
{
    [XmlAttribute("id")]
    public string id;

    [XmlElement("Name")]
    public string fullname;

    [XmlElement("Gender")]
    public string gender;

    [XmlElement("DOB")]
    public string birthdate;

    [XmlElement("Ethnicity")]
    public string ethnicity;

    [XmlArray("Traits")]
    [XmlArrayItem("Trait")]
    public List<string> traits = new List<string>();

    [XmlElement("Occupation")]
    public string occupation;

    [XmlElement("Skills")]
    public string skills;

    [XmlElement("Description")]
    public string description;
}