using UnityEngine;

public class LevelsControl : MonoBehaviour
{
    public void SetLevel(int levelSelected)
    {
        GameManager.Instance.LevelSelected = levelSelected;
    }
}