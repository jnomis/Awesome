using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
