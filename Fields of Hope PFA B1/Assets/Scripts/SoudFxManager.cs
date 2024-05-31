using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudFxManager : MonoBehaviour
{
    public static SoudFxManager Instance;

    [SerializeField] private AudioSource soundFxObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip clip, Transform transform, float volume)
    {
        AudioSource audio = Instantiate(soundFxObject, transform.position, Quaternion.identity);

        audio.clip = clip;
        audio.volume = volume;
        audio.Play();
        float cliplength = audio.clip.length;
        Destroy(audio.gameObject, cliplength);
    }

    public void PlayRandomSoundFXClip(AudioClip[] clip, Transform transform, float volume)
    {
        int rand = Random.Range(0, clip.Length);
        AudioSource audio = Instantiate(soundFxObject, transform.position, Quaternion.identity);

        audio.clip = clip[rand];
        audio.volume = volume;
        audio.Play();
        float cliplength = audio.clip.length;
        Destroy(audio.gameObject, cliplength);
    }
}
