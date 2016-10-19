using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawning : MonoBehaviour {

	CandidateAssociations associations;

	//Candidate A objects
	List<string> itemsA;
	Locations.Location houseA;
	string candidateA;
	List<bool> isPlacedA = new List<bool> ();

	//Candidate B objects
	List<string> itemsB;
	Locations.Location houseB;
	string candidateB;
	List<bool> isPlacedB = new List<bool> ();

//	int counter = 0;

	// Use this for initialization
	public void spawnItems () {
		associations = FindObjectOfType<CandidateAssociations> ();
		//itemsA = associations.itemNamesA;
		itemsA = new List<string>{ "Pill", "Diary" };
		candidateA = associations.CandidateAName;
		houseA = associations.houseA;

		Debug.Log ("the size of house a is: " + houseA.size);

		foreach (Vector3 location in houseA.itemSpawnLocations) {
			isPlacedA.Add(false);
		}




		itemsB = associations.itemNamesB;
		candidateB = associations.CandidateBName;
		houseB = associations.houseB;
		foreach (Vector3 location in houseB.itemSpawnLocations) {
			isPlacedB.Add(false);
		}

		System.Random rnd = new System.Random();

		for (int i = 0; i < itemsA.Count; i++) {
			bool hasPlaced = false;
			Debug.Log ("itemsA[" + i + "] = " + itemsA [i]);
			GameObject currentObject = GameObject.Find (itemsA [i]);

			while (!hasPlaced) {
				int place = rnd.Next (houseA.itemSpawnLocations.Length);
				if (!isPlacedA [place]) {
					currentObject.transform.position = houseA.itemSpawnLocations [place];
					isPlacedA [place] = true;
					hasPlaced = true;
				}
			}
		}

		/**
		while (counter < itemsA.Count) {
			int place = rnd.Next(houseA.itemSpawnLocations.Length);

			if (!isPlacedA [place]) {
				currentObject.transform.position = locations [place];
				isPlaced [place] = true;
				counter++;
			} else {
				Debug.Log ("Currently isPlaced[place] = true and place = " + place);
			}
		}
		*/
	}

	// Update is called once per frame
	void Update () {

	}
}
