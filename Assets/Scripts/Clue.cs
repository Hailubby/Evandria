using UnityEngine;
using System.Collections;
[System.Serializable]

// Clue object which is to be used to store clues in the Journal which the user will have.
public class Clue {
    public string clueName;
    public string clueOwner;
    public string clueDesc;

    public Clue(string name, string owner, string desc)
    {
        clueName = name;
        clueOwner = owner;
        clueDesc = desc;
    }

}
