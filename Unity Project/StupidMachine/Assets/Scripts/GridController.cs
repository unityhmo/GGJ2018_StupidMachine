using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

	public GameObject objGridPlaceholder;
	public GameObject objGearPlaceHolder;
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
	void GenerateGridHardCode()
	{
		int arreglador = 3;
		Vector3 spawnPosition = new Vector3(0,0 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(0,-1 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(0,-2 , 0);
		SpawnGearPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(0,-3 , 0);
		SpawnGridPlaceHolder (spawnPosition);

		spawnPosition = new Vector3(1,0 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(1,-1 , 0);
		SpawnGearPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(1,-2 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(1,-3 , 0);
		SpawnGearPlaceHolder (spawnPosition);

		spawnPosition = new Vector3(2,0 , 0);
		SpawnGearPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(2,-1 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(2,-2 , 0);
		SpawnGearPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(2,-3 , 0);
		SpawnGridPlaceHolder (spawnPosition);

		spawnPosition = new Vector3(3,0 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(3,-1 , 0);
		SpawnGearPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(3,-2 , 0);
		SpawnGridPlaceHolder (spawnPosition);
		spawnPosition= new Vector3(3,-3 , 0);
		SpawnGearPlaceHolder (spawnPosition);


	}
	
	
}
