using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _levelSelected = 0;

    private static GameManager _instance;
    public List<Level> _levels;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonInstance = new GameObject("GameManager");
                DontDestroyOnLoad(singletonInstance);
                _instance = singletonInstance.AddComponent<GameManager>();
                _instance.GetComponent<GameManager>()._levels = GenerateHardCodedLevels(); // TODO change this...
            }

            return _instance;
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public int LevelSelected
    {
        get { return _levelSelected; }
        set { _levelSelected = value; }
    }

    // DEBUG ---

    private static List<Level> GenerateHardCodedLevels()
    {
        List<Level> levels = new List<Level>();

        levels.Add(new Level(3, new List<int>(new int[] {0, 0, 4, 3, 3, 3,1,3,3})));
        levels.Add(new Level(3, new List<int>(new int[] {3, 2, 3, 3, 3, 3, 1, 3,4})));
		levels.Add(new Level(4, new List<int>(new int[] {3, 3, 3, 4, 3, 3, 3, 0,1,3,3,2})));
		levels.Add(new Level(3, new List<int>(new int[] {0, 2, 4, 0, 3, 3,1,3,3})));

        return levels;
    }
}