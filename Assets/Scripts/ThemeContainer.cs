using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot(ElementName = "ThemeCollection")]
public class ThemeContainer {

    [XmlArray("Themes"), XmlArrayItem("Theme")]
    //public List<Theme> Themes = new List<Theme>();
    public Theme[] Themes;

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ThemeContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static ThemeContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ThemeContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ThemeContainer;
        }
    }

    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static ThemeContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ThemeContainer));
        return serializer.Deserialize(new StringReader(text)) as ThemeContainer;
    }
}
