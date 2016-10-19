using UnityEngine;
using System.Collections;

public class Locations : MonoBehaviour {
    public ArrayList locations;
    public bool isGenerated = false;

    // Use this for initialization
    void Start() {
        //hard coded filler vectors for location spawn points
        Vector3[] officeSpawn = { new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Vector3(2, 2, 0) };
        Vector3[] medium_1Spawn = { new Vector3(5, 5, 0), new Vector3(10, 10, 0), new Vector3(15, 15, 0), new Vector3(20, 20, 0), new Vector3(25, 25, 0) };
        Vector3[] small_1Spawn = { new Vector3(-5, -5, 0), new Vector3(-10, -10, 0), new Vector3(-15, -15, 0), new Vector3(-20, -20, 0), new Vector3(-25, -25, 0) };
        Vector3[] medium_2Spawn = { new Vector3(100, 100, 0), new Vector3(110, 110, 0), new Vector3(120, 120, 0), new Vector3(130, 130, 0), new Vector3(140, 140, 0) };
        Vector3[] small_2Spawn = { new Vector3(-100, -100, 0), new Vector3(-110, -110, 0), new Vector3(-120, -120, 0), new Vector3(-130, -130, 0), new Vector3(-140, -140, 0) };

        locations = new ArrayList();
        locations.Add(new Location(new Vector3(17.5f, 24.5f, 0), "Office", officeSpawn));
        locations.Add(new Location(new Vector3(99.5f, -20, 0), "Medium", medium_1Spawn));
        locations.Add(new Location(new Vector3(-120, 6, 0), "Small", small_1Spawn));
        locations.Add(new Location(new Vector3(-201.5f, -25, 0), "Medium", medium_2Spawn));
        locations.Add(new Location(new Vector3(-321, 8, 0), "Small", small_2Spawn));
    }

    // Update is called once per frame
    void Update() {

    }

    void AddLocation(string size, Vector3 position, Vector3[] spawnLocations)
    {
        locations.Add(new Location(position, size, spawnLocations)); 
    }
	
	public class Location { 
		public Vector3 entrance;
		public string size;
        public Vector3[] itemSpawnLocations;

		public Location(Vector3 entrance, string size, Vector3[] itemSpawnLocations){
			this.entrance = entrance;
			this.size = size;
            this.itemSpawnLocations = itemSpawnLocations;
		}
	}

}

