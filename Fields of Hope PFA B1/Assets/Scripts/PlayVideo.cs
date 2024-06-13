using System;
using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField]
    private PlayMusic play;

    [SerializeField]
    private GameObject PanelText;

    [SerializeField] 
    private GameObject Logo;

    [SerializeField]
    private DialogueBox dialogue;

    [SerializeField] 
    private GameObject MenuCin�matic;

    [SerializeField]
    GameObject ImageAnimation;

    [SerializeField]
    private VideoPlayer videoplayer;

    [SerializeField]
    private AudioClip AudioClip;

    [SerializeField]
    private AudioSource AudioSource;

    [SerializeField]
    private SoundSFXManager _soundSFXManager;


    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
    }

    public void OnPlayVideo()
    {
        if (videoplayer)
        {
            MenuCin�matic.SetActive(true);
            StartCoroutine(StartVideo());           
        }
    }

    public void Skip()
    {
        PlaySoundVideo(true);
        dialogue.StopAllCoroutines();
        StopAllCoroutines();
        videoplayer.Stop();
        AudioSource.Stop();
        PanelText.SetActive(false);
        MenuCin�matic.SetActive(false);
        play.PlayNextMusic();
        StartCoroutine(FindAnyObjectByType<TimePostProcessHandler>().BasisProcess());
    }

    private IEnumerator StartVideo()
    {
        PlaySoundVideo(false);
        yield return new WaitForSecondsRealtime(0.40f);
        videoplayer.Play();
        yield return new WaitForSecondsRealtime(0.05f);
        ImageAnimation.SetActive(true);
        yield return new WaitForSecondsRealtime(11f);
        PanelText.SetActive(true);
        dialogue.StartDialogue("Au d�but du 21�me si�cle, une attaque terroriste d�clenche une guerre entre les puissances mondiales WEST et EST, entra�nant des frappes nucl�aires d�vastatrices. ");
        yield return new WaitForSecondsRealtime(8f);
        dialogue.StartDialogue("Les nations sont en ruines et les survivants doivent naviguer dans un monde post-apocalyptique.");
        yield return new WaitForSecondsRealtime(5f);
        dialogue.StartDialogue("Vous, joueur, devez survivre, reconstruire et apporter de l�espoir � ce monde bris�.");
        yield return new WaitForSecondsRealtime(5f);
        Logo.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        PanelText.SetActive(false);
        ImageAnimation.SetActive(false);
        yield return new WaitForSecondsRealtime(2.8f);
        Logo.SetActive(false);
        StartCoroutine(FindAnyObjectByType<TimePostProcessHandler>().BasisProcess());
        MenuCin�matic.SetActive(false);
        play.PlayNextMusic();
    }

    private void PlaySoundVideo(bool stop)
    {
        AudioSource Source = AudioSource;
        Source.clip = AudioClip;
        if (stop == true)
        {
            Source.Stop();
        }
        else
        {
            Source.volume = 1f;
            Source.Play();
        }
    }
}
