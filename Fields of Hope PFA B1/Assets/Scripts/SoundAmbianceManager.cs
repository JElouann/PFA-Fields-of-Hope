using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAmbianceManager : MonoBehaviour
{
    public static SoundAmbianceManager Instance;

    [SerializeField] private AudioSource SoundAmbiance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip clip, Transform transform, float volume)
    {
        AudioSource audio = Instantiate(SoundAmbiance, transform.position, Quaternion.identity);
        audio.clip = clip;
        audio.volume = volume;
        audio.Play();
        float cliplength = audio.clip.length;
        Destroy(audio.gameObject, cliplength);
    }
}
