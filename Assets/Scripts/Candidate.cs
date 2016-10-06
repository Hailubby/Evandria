using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

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

    // The loader doesn't like traits, I'll fix this tomorrow
    //[XmlElement("Traits")]
    //public string[] traits;

    [XmlElement("Occupation")]
    public string occupation;

    [XmlElement("Skills")]
    public string skills;

    [XmlElement("Description")]
    public string description;
}