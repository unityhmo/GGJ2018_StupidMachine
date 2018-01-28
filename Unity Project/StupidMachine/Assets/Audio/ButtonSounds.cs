using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonClick;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = AudioManager.Instance;
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(PlayGearClickSound);
    }

    public void PlayGearClickSound()
    {
        _audioManager.PlaySound(_buttonClick);
    }
}