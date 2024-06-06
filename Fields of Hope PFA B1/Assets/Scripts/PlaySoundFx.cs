using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFx : MonoBehaviour
{
    [SerializeField]
    private SoundSFXManager soundFxManager;

    private AudioClip _audio;

    [SerializeField]
    private AudioClip[] Music;

    public void OnClick(AudioClip clip)
    {
       _audio = clip;
    }

    public void OnPlaySFXSound(string popilopo)
    {
        soundFxManager.PlaySoundFXClip(_audio, transform, 1f, popilopo);
    }
}
