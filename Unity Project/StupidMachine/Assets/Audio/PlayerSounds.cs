using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _gearClick;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    public void PlayGameMusic()
    {
        _audioManager.PlayMusic(_gameMusic);
    }

    public void PlayGearClickSound()
    {
        _audioManager.PlaySound(_gearClick);
    }
}