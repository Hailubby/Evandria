﻿using UnityEngine;
using System.Collections;

public class Locations : MonoBehaviour {
    public ArrayList locations;
    public bool isGenerated = false;

    // Use this for initialization
    void Start() {
        locations = new ArrayList();
        locations.Add(new Location(new Vector3(17.5f, 24.5f, 0), "Office"));
        locations.Add(new Location(new Vector3(100,-5,0), "Sample"));
    }

    // Update is called once per frame
    void Update() {

    }

    void AddLocation(string name, Vector3 position)
    {
        locations.Add(new Location(position, name)); 
    }
	
	public class Location { 
		public Vector3 entrance;
		public string name;

		public Location(Vector3 entrance, string name){
			this.entrance = entrance;
			this.name = name;
		}
	}

}
