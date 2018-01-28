using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonInstance = new GameObject("AudioManager");
                DontDestroyOnLoad(singletonInstance);
                _instance = singletonInstance.AddComponent<AudioManager>();
            }

            return _instance;
        }
    }

    private AudioSource myMusicPlayer;
    private List<AudioSource> effects;

    void Awake()
    {
        if (myMusicPlayer == null)
        {
            myMusicPlayer = gameObject.AddComponent<AudioSource>();
            effects = new List<AudioSource>();
        }
    }

    void LateUpdate()
    {
        effects.ForEach(sfx =>
        {
            if (!sfx.isPlaying)
            {
                Destroy(sfx);
                effects.Remove(sfx);
            }
        });
    }

    public void PlayMusic(AudioClip music)
    {
        if (myMusicPlayer.clip == music)
        {
            return;
        }

        myMusicPlayer.Stop();
        myMusicPlayer.clip = music;
        myMusicPlayer.Play();
        myMusicPlayer.loop = true;
    }

    public void PlaySound(AudioClip sfx)
    {
        AudioSource tmpAudioSource = gameObject.AddComponent<AudioSource>();
        tmpAudioSource.clip = sfx;
        tmpAudioSource.Play();

        effects.Add(tmpAudioSource);
    }
}