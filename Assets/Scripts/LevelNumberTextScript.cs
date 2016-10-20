using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelNumberTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Text>().text = EvandriaUpdate.level.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
