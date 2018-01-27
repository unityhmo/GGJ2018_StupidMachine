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
		GenerateGridHardCode();
	}

	void GenerateGrid()
	{
		for (int row = 0; row < numberOfRows; row++) {
			bool columnWithGrid = false;
			for (int column = 0; column < numberOfColumns; column++) {
				Vector3 spawnPosition = new Vector3(row,column , 0);
				if (!columnWithGrid && column == Random.Range (column, numberOfColumns)) {
					SpawnGearPlaceHolder (spawnPosition);
					columnWithGrid = true;
				} else {
					SpawnGridPlaceHolder (spawnPosition);
				}
			}
		}
	}

	void SpawnGridPlaceHolder(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objGridPlaceholder, spawnPosition, Quaternion.identity) as GameObject;
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
