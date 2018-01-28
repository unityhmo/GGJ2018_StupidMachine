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

	public int numberOfGoodPivots;
	public bool AllPivotsOnSequence;
	public List<int> listPosition;

	public List<int> positionsOnSequence;

	void Start () {
		ResumeTime ();
		SetWinItem ();
		InvokeRepeating ("HandleTime", 1, 1);
		CheckAllGoodPivots ();
	}

	void CheckAllGoodPivots()
	{
		GameObject[] arrayPivots = GameObject.FindGameObjectsWithTag("Pivot");
		if (arrayPivots != null) {
			
			foreach (GameObject objPivot in arrayPivots) {
				if (objPivot.GetComponent<Pivot> ().position > 0) {
					numberOfGoodPivots++;
				}
			}
		}
	}

	void ValidatePivotsSequence()
	{

		GameObject[] arrayPivots = GameObject.FindGameObjectsWithTag("Pivot");
		if (arrayPivots != null) {
			int counter = 0;
			foreach (GameObject objPivot in arrayPivots) {
				if (objPivot.GetComponent<Pivot> ().position > 0) {
					if (objPivot.GetComponent<Pivot> ().IsBusy) {
						bool hasThisValue = false;
						foreach(int item in listPosition)
						{
							if (item==objPivot.GetComponent<Pivot> ().position)
								hasThisValue = true;
						}
						if (!hasThisValue) {
							listPosition.Add (objPivot.GetComponent<Pivot> ().position);
						} else {
							listPosition.Remove (objPivot.GetComponent<Pivot> ().position);
							objPivot.GetComponent<Pivot> ().pivotOnSequence = false;
							AllPivotsOnSequence = false;
						}

						counter++;
						//objPivot.GetComponent<Pivot> ().pivotOnSequence = true;
						listPosition.Sort ();
						int currPosition = 1;
						bool isOnSequence = false;;
						foreach (int values in listPosition) {
							if (values == currPosition) {
								isOnSequence = true;
							} else {
								isOnSequence = false;
								break;
							}
							currPosition++;
						}
						objPivot.GetComponent<Pivot> ().pivotOnSequence = isOnSequence;
					}
				}
			}

	


			if (counter >= numberOfGoodPivots) {
				listPosition.Sort ();
				int position = 1;
				foreach (int value in listPosition) {
					Debug.Log ("Position: " + position + " value: " + value);
					if (value == position) {
						AllPivotsOnSequence = true;
					}
					position++;
				}
			}
			counter = 0;

			if (AllPivotsOnSequence) {
				WinGame ();
			}
		}
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
		ValidatePivotsSequence ();
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
		//Time.timeScale = 0;
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
