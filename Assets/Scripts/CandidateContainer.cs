using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("CandidateCollection")]
public class CandidateContainer {

    [XmlArray("Candidates")]
    [XmlArrayItem("Candidate")]
    public List<Candidate> candidates { get; set; }

    public static CandidateContainer Load(string path) {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(CandidateContainer));
        StringReader reader = new StringReader(_xml.text);
        CandidateContainer candidates = serializer.Deserialize(reader) as CandidateContainer;
        reader.Close();
        return candidates;
    }

}
