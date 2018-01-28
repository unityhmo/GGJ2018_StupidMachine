using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

	public GameObject objGridPlaceholder;
	public GameObject objGearPlaceHolder;
	public GameObject objStart;
	public GameObject objFinish;
	public GameObject objGear;

	public int numberOfRows;
	public int numberOfColumns;

	public List<Level> levels;
	
	private Level currentLevel;
	
	void Start(){
		currentLevel = GameManager.Instance._levels[GameManager.Instance.LevelSelected];
		GenerateGrid();
		GenerateGears();
	}

	void GenerateGears(){
		for (int x = 0; x < numberOfColumns; x++) {
			Vector3 spawnPosition = new Vector3(x+x*(1+0.2f)-3,-3, 0);
			SpawnGear (spawnPosition);
		}
	}

	public void DestroyGrid()
	{
		DestroyByTag("GearHolder");
		DestroyByTag("GridFinish");
		DestroyByTag("GridObject");
		DestroyByTag("GridStart");
		DestroyByTag("Pivot");
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
		numberOfColumns = currentLevel.blocks.Count / currentLevel.rowSize;
		numberOfRows = currentLevel.rowSize;
		int row = 0;
		int column = 0;
		int counter = 0;
		Vector2 offset = currentLevel.offset != null ? currentLevel.offset : new Vector2(0, 0);

		foreach (int valor in currentLevel.blocks) {
			Vector3 spawnPosition =
				new Vector3(row + currentLevel.offset.x * (0.5f), column + currentLevel.offset.y * (0.5f), 0);
			row++;
			if (row == numberOfColumns) {
				row = 0;
				column--;
			}
			switch (valor)
			{
			case 0:
				SpawnGridPlaceHolder (spawnPosition);
				break;
			case 1:
				SpawnStart (spawnPosition);
				break;
			case 2:
				SpawnFinish (spawnPosition);
				break;
			case 3:
				SpawnGearPlaceHolder (spawnPosition);
				break;
			case 4:
				SpawnFinish (spawnPosition); //< --- This is the finish that wins the game
				break;
			default:
				SpawnGridPlaceHolder (spawnPosition);
				break;
			}
			counter++;
		}
	}

	void SpawnGridPlaceHolder(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objGridPlaceholder, spawnPosition, Quaternion.identity) as GameObject;
	}

	void SpawnGearPlaceHolder(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objGearPlaceHolder, spawnPosition, Quaternion.identity) as GameObject;
		bPrefab.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
	}

	void SpawnStart(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objStart, spawnPosition, Quaternion.identity) as GameObject;
		bPrefab.GetComponent<Gear>().IsPlacedInGrid = true;
	}

	void SpawnGear(Vector3 spawnPosition)
	{
		GameObject bPrefab = Instantiate (objGear, spawnPosition, Quaternion.identity) as GameObject;
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
