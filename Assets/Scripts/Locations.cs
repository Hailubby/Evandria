using UnityEngine;
using System.Collections;

public class Locations : MonoBehaviour {
    public ArrayList locations;
    public bool isGenerated = false;

    // Use this for initialization
    void Start() {
        //hard coded filler vectors for location spawn points
        Vector3[] officeSpawn = { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
        Vector3[] townSpawn = { new Vector3(-105.9f, -220.2f, 0), new Vector3(-109, -194.4f, 0), new Vector3(-102.8f, -162.2f, 0), new Vector3(-90, -194, 0), new Vector3(-77.2f, -210, 0), new Vector3(-70.6f, -191, 0), new Vector3(-61.5f, -200.5f, 0), new Vector3(-48.2f, -162, 0), new Vector3(-32, -213, 0), new Vector3(-23, -181.2f, 0), new Vector3(-19.7f, -162.4f, 0) };
        Vector3[] medium_1Spawn = { new Vector3(110.3f, 1.1f, 0), new Vector3(113.6f, 1.1f, 0), new Vector3(116.8f, 1.1f, 0), new Vector3(72.1f, 23.5f, 0), new Vector3(75.2f, 23.5f, 0) };
        Vector3[] small_1Spawn = { new Vector3(-102.3f, -73, 0), new Vector3(-99, -73, 0), new Vector3(-95.8f, -73, 0), new Vector3(-108.5f, -73, 0), new Vector3(-112, -73, 0) };
        Vector3[] medium_2Spawn = { new Vector3(95.9f, -91.2f, 0), new Vector3(73.5f, -84.7f, 0), new Vector3(67, -84.7f, 0), new Vector3(131, -75, 0), new Vector3(134.2f, -75, 0) };
        Vector3[] small_2Spawn = { new Vector3(-86.5f, 16.5f, 0), new Vector3(83.4f, 16.5f, 0), new Vector3(-80.2f, 16, 0), new Vector3(-77, 16, 0), new Vector3(-76.9f, -3, 0) };

        locations = new ArrayList();
        locations.Add(new Location(new Vector3(-13, -5, 0), "Office", officeSpawn));
        locations.Add(new Location(new Vector3(-48, -220, 0), "Town Square", townSpawn));
        locations.Add(new Location(new Vector3(99.5f, -21, 0), "Medium", medium_1Spawn));
        locations.Add(new Location(new Vector3(-123, -98.5f, 0), "Small", small_1Spawn));
        locations.Add(new Location(new Vector3(120, -79, 0), "Medium", medium_2Spawn));
        locations.Add(new Location(new Vector3(-123, 13, 0), "Small", small_2Spawn));
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

