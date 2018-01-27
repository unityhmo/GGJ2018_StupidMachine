using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _levelSelected = 0;

    private static GameManager _instance;
    private List<Level> _levels;

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

        levels.Add(new Level(3, new List<int>(new int[] {0, 0, 0, 0, 0, 0})));
        levels.Add(new Level(4, new List<int>(new int[] {0, 0, 0, 0, 0, 0, 0, 0})));

        return levels;
    }
}