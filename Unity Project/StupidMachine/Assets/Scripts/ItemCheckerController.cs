using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheckerController : MonoBehaviour {

	public 	GameObject objController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		objController.GetComponent<GameController> ().itemProduced = other.gameObject.name;
		objController.GetComponent<GameController> ().CheckItemToWin ();
	}

	private void OnCollisionEnter(Collision other)
	{
		objController.GetComponent<GameController> ().itemProduced = other.gameObject.name;
		objController.GetComponent<GameController> ().CheckItemToWin ();
	}
}
