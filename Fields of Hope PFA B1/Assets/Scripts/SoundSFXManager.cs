using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public enum SFXType
{
    Ambiance,
    SFX,
    Musique
}
public class SoundSFXManager : MonoBehaviour
{

    public static SoundSFXManager Instance;

    [SerializeField] 
    private AudioSource soundFxObject;

    [SerializeField]
    private AudioSource AmbianceObject;

    [SerializeField]
    private AudioSource MusicObject;

    [SerializeField]
    private AudioMixerGroup AudioMixer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip clip, Transform transform, float volume, string sound)
    {
        if (sound == "Music")
        {
            AudioSource audio = Instantiate(MusicObject, transform.position, Quaternion.identity);
            audio.clip = clip;
            audio.volume = volume;
            audio.Play();
            float cliplength = audio.clip.length;
            Destroy(audio.gameObject, cliplength);
        }

        else if (sound == "SFX")
        {
            AudioSource audio = Instantiate(soundFxObject, transform.position, Quaternion.identity);
            audio.clip = clip;
            audio.volume = volume;
            audio.Play();
            float cliplength = audio.clip.length;
            Destroy(audio.gameObject, cliplength);
        }

        else if (sound == "Ambiance")
        {
            AudioSource audio = Instantiate(AmbianceObject, transform.position, Quaternion.identity);
            audio.clip = clip;
            audio.volume = volume;
            audio.Play();
            float cliplength = audio.clip.length;
            Destroy(audio.gameObject, cliplength);
        }
    }

    public void PlayRandomSoundFXClip(AudioClip[] clip, Transform transform, float volume)
    {
        int rand = UnityEngine.Random.Range(0, clip.Length);
        AudioSource audio = Instantiate(soundFxObject, transform.position, Quaternion.identity);

        audio.clip = clip[rand];
        audio.volume = volume;
        audio.Play();
        float cliplength = audio.clip.length;
        Destroy(audio.gameObject, cliplength);
    }
}
