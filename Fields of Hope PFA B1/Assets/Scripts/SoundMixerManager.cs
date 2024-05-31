using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterMain", Mathf.Log10(level)*20);
    }

    public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(level) * 20);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(level) * 20);
    }

    public void SetAmbianceVolume(float level)
    {
        audioMixer.SetFloat("Ambiance", Mathf.Log10(level) * 20);
    }
}
