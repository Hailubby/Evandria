using System.Xml;
using System.Xml.Serialization;

// A model of a theme instance
public class Theme {

    [XmlAttribute("selected")]
    public bool Selected;
    public string Name;
    public string FontColour;
    public string BGColour;

}
