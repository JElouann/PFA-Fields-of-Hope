using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> AudioList;

    [SerializeField]
    private AudioSource audioSource;

    public void PlayRandomSoundFXClip()
    {
        int randomIndex = Random.Range(0, AudioList.Count);
        AudioClip randomClip = AudioList[randomIndex];

        AudioSource audio = audioSource;
        audio.clip = randomClip;
        audio.volume = 1f;
        audio.Play();
    }
}
