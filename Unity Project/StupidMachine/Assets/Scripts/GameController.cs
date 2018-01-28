using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Canvas CanvasManager;
	public Canvas WinCanvas;
	public Canvas LoseCanvas;
	public GameObject[] ArrayItems;
	public GameObject itemDroper;
	public GameObject winItem;
	public Text txtTime;
	string itemToWinName;

	public string itemProduced;
	public int minutes;
	public int seconds;

	bool timesUp;
	void Start () {
		ResumeTime ();
		SetWinItem ();
		InvokeRepeating ("HandleTime", 1, 1);
	}

	void HandleTime()
	{
		seconds =seconds-1;
		if (seconds <= 0) {
			seconds = 59;
			minutes = minutes-1;
		}
		if (minutes < 0) {
			LoseGame ();
			timesUp = true;
		}

	}

	public void SetTimeText()
	{
		string zeroMinutes = "";
		string zeroSeconds = "";
		if (minutes < 10) {
			zeroMinutes = "0";
		}
		if (seconds < 10) {
			zeroSeconds = "0";
		}
		if (!timesUp) {
			txtTime.text = "Time: " + zeroMinutes + minutes.ToString () + ":" + zeroSeconds + seconds.ToString ();
		} else {
			txtTime.text = "Time: 00:00";
		}
	}

	void SetWinItem()
	{
		Vector3 firePosition = new Vector3(-3, 5, 0);
		int index = Random.Range (0, ArrayItems.Length);
		GameObject randomItem = ArrayItems [index];
		GameObject bPrefab = Instantiate(randomItem, firePosition, Quaternion.identity) as GameObject;
		Destroy (bPrefab.GetComponent<Rigidbody> ());
		itemToWinName = bPrefab.gameObject.name;
	}

	void Update () {
		SetTimeText ();
	}

	public void WinGame(){
		WinCanvas.gameObject.SetActive (true);
		LoseCanvas.gameObject.SetActive (false);
		StopTime ();
	}

	public void LoseGame(){
		WinCanvas.gameObject.SetActive (false);
		LoseCanvas.gameObject.SetActive (true);
		StopTime ();
	}

	public void DropItem(){

		Vector3 firePosition = new Vector3(itemDroper.transform.position.x, itemDroper.transform.position.y, 0);
			int index = Random.Range (0, ArrayItems.Length);
			GameObject randomItem = ArrayItems [index];
			GameObject bPrefab = Instantiate(randomItem, firePosition, Quaternion.identity) as GameObject;

	}

	public void StopTime(){
		Time.timeScale = 0;
	}

	public void ResumeTime(){
		Time.timeScale = 1;
	}


	public void ReloadScene()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void CheckItemToWin()
	{
		if (itemProduced.Contains (itemToWinName)) {
			WinGame ();
		}
	}

}
