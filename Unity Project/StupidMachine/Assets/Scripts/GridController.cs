using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

	public GameObject objGridPlaceholder;
	public GameObject objGearPlaceHolder;
	public GameObject objStart;
	public GameObject objFinish;

	public int numberOfRows;
	public int numberOfColumns;

	// Use this for initialization
	void Start () {
		GenerateGrid();
	}

	public void DestroyGrid()
	{
		DestroyByTag("GearHolder");
		DestroyByTag("GridFinish");
		DestroyByTag("GridObject");
		DestroyByTag("GridStart");
	}

	public void DestroyByTag(string tag)
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (tag);

		for(var i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
		}
	}

	public void GenerateNewGrid()
	{
		DestroyGrid ();
		GenerateGrid ();
	}

	void GenerateGrid()
	{
		for (int row = 0; row < numberOfRows; row++) {
			bool columnWithGrid = false;
			for (int column = 0; column < numberOfColumns; column++) {
				Vector3 spawnPosition = new Vector3(row,column , 0);
				if (column == 0 && row == 0) {
					SpawnStart (spawnPosition);
				} else {
					//Last Column
					if (row == numberOfRows-1) {
						if (column % 2 == 0) {
							SpawnFinish (spawnPosition);
						} else {
							if (!columnWithGrid && column == Random.Range (column, numberOfColumns)) {
								SpawnGearPlaceHolder (spawnPosition);
								columnWithGrid = true;
							} else {
								SpawnGridPlaceHolder (spawnPosition);
							}
						}
					} else {
						if (!columnWithGrid && column == Random.Range (column, numberOfColumns)) {
							SpawnGearPlaceHolder (spawnPosition);
							columnWithGrid = true;
						} else {
							SpawnGridPlaceHolder (spawnPosition);
						}
					}

				}
			}
		}
	}

	void SpawnGridPlaceHolder(Vector3 spawnPosition)
	{
		int wildCard = Random.Range (0, 2);
		if (wildCard == 1) {
			GameObject bPrefab = Instantiate (objGridPlaceholder, spawnPosition, Quaternion.identity) as GameObject;
		} else {
			SpawnGearPlaceHolder (spawnPosition);
		}
	}

	void SpawnGearPlaceHolder(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objGearPlaceHolder, spawnPosition, Quaternion.identity) as GameObject;
	}

	void SpawnStart(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objStart, spawnPosition, Quaternion.identity) as GameObject;
	}

	void SpawnFinish(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objFinish, spawnPosition, Quaternion.identity) as GameObject;
	}

	void GenerateGridHardCode()
	{
		Vector3 spawnPosition = new Vector3(0,0 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(0,-1 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(0,-2 , 0);
		SpawnFinish (spawnPosition);

		spawnPosition = new Vector3(1,0 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(1,-1 , 0);
		SpawnGearPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(1,-2 , 0);
		SpawnGridPlaceHolder (spawnPosition);

		spawnPosition = new Vector3(2,0 , 0);
		SpawnStart (spawnPosition);
		spawnPosition= new Vector3(2,-1 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(2,-2 , 0);
		SpawnGridPlaceHolder (spawnPosition);

	}
}
