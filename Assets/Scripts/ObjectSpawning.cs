using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawning : MonoBehaviour {
	
	CandidateAssociations associations;
	Locations.Location townSquare;
	int numberOfAvailableNPC = 2;

	//Town square variables for spawning NPC
	int npcToUse;
	int npcSpawnPoint;
	List<bool> isPlacedInTown = new List<bool>();
	bool placedNPC = false;
	bool[] npcIsUsed = new bool[2];

	//Candidate A objects
	List<string> itemsA;
	Locations.Location houseA;
	string candidateA;
	List<bool> isPlacedA = new List<bool>();
	string npcNameA;

	//Candidate B objects
	List<string> itemsB;
	Locations.Location houseB;
	string candidateB;
	List<bool> isPlacedB = new List<bool>();
	string npcNameB;

	// Use this for initialization
	public void spawnItems() {
		associations = FindObjectOfType<CandidateAssociations>();
		townSquare = (Locations.Location)associations.locations[1];
		for (int i = 0; i < npcIsUsed.Length; i++) {
			npcIsUsed[i] = false;
		}

		/**
         * Change the below code to dynamically change items
         **/
		//itemsA = associations.itemNamesA;
		itemsA = new List<string> { "Pill", "Diary" };
		candidateA = associations.CandidateAName;
		houseA = associations.houseA;
		foreach (Vector3 location in houseA.itemSpawnLocations) {
			isPlacedA.Add(false);
		}
		npcNameA = candidateA + "_NPC";


		//itemsB = associations.itemNamesB;
		itemsB = new List<string> { "Knife", "Old Disc"};
		candidateB = associations.CandidateBName;
		houseB = associations.houseB;
		foreach (Vector3 location in houseB.itemSpawnLocations) {
			isPlacedB.Add(false);
		}
		npcNameB = candidateB + "_NPC";

		foreach (Vector3 location in townSquare.itemSpawnLocations) {
			isPlacedInTown.Add(false);
		}

		System.Random rnd = new System.Random();

		// randomly placing clue items for candidate A
		for (int i = 0; i < itemsA.Count; i++) {
			bool hasPlaced = false;
			GameObject currentObject = GameObject.Find(itemsA[i]);

			while (!hasPlaced) {
				int place = rnd.Next(houseA.itemSpawnLocations.Length);
				if (!isPlacedA[place]) {
					currentObject.transform.position = houseA.itemSpawnLocations[place];
					isPlacedA[place] = true;
					hasPlaced = true;
				}
			}
		}

		// randomly placing clue items for candidate B
		for (int i = 0; i < itemsB.Count; i++) {
			bool hasPlaced = false;
			GameObject currentObject = GameObject.Find(itemsB[i]);
			Debug.Log ("itemsB[" + i + "] is: " + itemsB [i]);

			while (!hasPlaced) {
				int place = rnd.Next(houseB.itemSpawnLocations.Length);
				if (!isPlacedB[place]) {
					currentObject.transform.position = houseB.itemSpawnLocations[place];
					isPlacedB[place] = true;
					hasPlaced = true;
				}
			}
		}

		// spawning NPC for candidate A
		Debug.Log("About to spawn NPC for candidate A: " + npcNameA);
		GameObject currentNPC = Resources.Load("NPC/" + npcNameA) as GameObject;

		while (!placedNPC) {
			npcSpawnPoint = rnd.Next(townSquare.itemSpawnLocations.Length);
			if (!isPlacedInTown[npcSpawnPoint]) {
				currentNPC.transform.position = townSquare.itemSpawnLocations[npcSpawnPoint];
				isPlacedInTown[npcSpawnPoint] = true;
				placedNPC = true;
			}
		}
		Debug.Log ("Placed NPC for candidate A and about to do candidate B NPC");

		currentNPC = Resources.Load("NPC/" + npcNameA) as GameObject;
		placedNPC = false;

		while (!placedNPC) {
			npcSpawnPoint = rnd.Next(townSquare.itemSpawnLocations.Length);
			if (!isPlacedInTown[npcSpawnPoint]) {
				currentNPC.transform.position = townSquare.itemSpawnLocations[npcSpawnPoint];
				isPlacedInTown[npcSpawnPoint] = true;
				placedNPC = true;
			}
		}

		for (int i = 0; i < 2; i++) {
			placedNPC = false;
			npcToUse = Random.Range(1, 3);

			while (npcIsUsed[npcToUse - 1]) {
				npcToUse = Random.Range(1, 3);
			}

			Debug.Log ("npcToUse = " + npcToUse);
			currentNPC = Resources.Load("NPC/npc" + npcToUse) as GameObject;

			while (!placedNPC) {
				npcSpawnPoint = rnd.Next(townSquare.itemSpawnLocations.Length);
				if (!isPlacedInTown[npcSpawnPoint]) {
					currentNPC.transform.position = townSquare.itemSpawnLocations[npcSpawnPoint];
					isPlacedInTown[npcSpawnPoint] = true;
					placedNPC = true;
					npcIsUsed[npcToUse - 1] = true;
				}
			}
		}
	}

	// Update is called once per frame
	void Update() {

	}
}
