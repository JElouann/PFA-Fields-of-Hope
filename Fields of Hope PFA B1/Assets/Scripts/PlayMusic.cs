using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> MusicList;

    [SerializeField]
    List<AudioClip> MusicListPlayed;

    [SerializeField]
    private AudioSource MusicObject;

    private int currentMusicIndex = 0;

    public void PlayRandomMusic(float volume)
    {
        if (MusicList.Count == 0)
        {
            MusicList = MusicListPlayed;
            MusicListPlayed = null;
        }

        int randomIndex = Random.Range(0, MusicList.Count);
        AudioClip randomClip = MusicList[randomIndex];

        AudioSource audio = MusicObject;
        audio.clip = randomClip;
        audio.volume = volume;
        audio.Play();

        MusicListPlayed.Add(randomClip);

        MusicList.RemoveAt(randomIndex);

        float cliplength = audio.clip.length;
        Invoke(nameof(PlayNextMusic), cliplength);
    }

    public void PlayNextMusic()
    {
        PlayRandomMusic(1f);
    }
}