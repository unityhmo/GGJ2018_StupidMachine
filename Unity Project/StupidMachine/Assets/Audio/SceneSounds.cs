using UnityEngine;

public class SceneSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _winGameMusic;
    [SerializeField] private AudioClip _loseGameMusic;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
        PlayGameMusic();
    }

    public void PlayGameMusic()
    {
        _audioManager.PlayMusic(_gameMusic);
    }

    public void PlayWinGameMusic()
    {
        _audioManager.PlaySound(_winGameMusic);
    }

    public void PlayLoseGameMusic()
    {
        _audioManager.PlaySound(_loseGameMusic);
    }
}