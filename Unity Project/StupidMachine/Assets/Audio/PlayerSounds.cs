using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _gearClick;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    public void PlayGearClickSound()
    {
        _audioManager.PlaySound(_gearClick);
    }
}