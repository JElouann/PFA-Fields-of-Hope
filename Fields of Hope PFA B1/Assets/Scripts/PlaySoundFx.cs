using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFx : MonoBehaviour
{
    [SerializeField]
    private SoundSFXManager soundFxManager;

    private AudioClip _audio;

    private void Awake()
    {
        if (soundFxManager == null)
        {
            soundFxManager = FindAnyObjectByType<SoundSFXManager>();
        }   
    }

    public void OnClick(AudioClip clip)
    {
       _audio = clip;
    }

    public void OnPlaySFXSound(string popilopo)
    {
        soundFxManager.PlaySoundFXClip(_audio, transform, 1f, popilopo);
    }
}
