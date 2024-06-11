using System;
using System.Collections;
using System.Diagnostics;
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
    private GameObject MenuCinématic;

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
            MenuCinématic.SetActive(true);
            StartCoroutine(StartVideo());           
        }
    }

    public void Skip()
    {
        videoplayer.Stop();
        AudioSource.Stop();
        PanelText.SetActive(false);
        MenuCinématic.SetActive(false);
    }

    private IEnumerator StartVideo()
    {
        _soundSFXManager.PlaySoundFXClip(AudioClip, gameObject.transform, 1f, "Ambiance");
        yield return new WaitForSecondsRealtime(0.40f);
        videoplayer.Play();
        yield return new WaitForSecondsRealtime(0.05f);
        ImageAnimation.SetActive(true);
        yield return new WaitForSecondsRealtime(10.5f);
        PanelText.SetActive(true);
        dialogue.StartDialogue("Au début du 21ème siècle, une attaque terroriste déclenche une guerre entre les puissances mondiales WEST et EST, entraînant des frappes nucléaires dévastatrices. ");
        yield return new WaitForSecondsRealtime(10f);
        dialogue.StartDialogue("Les nations sont en ruines et les survivants doivent naviguer dans un monde post-apocalyptique.");
        yield return new WaitForSecondsRealtime(7f);
        dialogue.StartDialogue("Vous, joueur, devez survivre, reconstruire et apporter de l’espoir à ce monde brisé.");
        yield return new WaitForSecondsRealtime(7f);
        Logo.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        PanelText.SetActive(false);
        ImageAnimation.SetActive(false);
        yield return new WaitForSecondsRealtime(0);
        Logo.SetActive(false);
        StartCoroutine(FindAnyObjectByType<TimePostProcessHandler>().BasisProcess());
        MenuCinématic.SetActive(false);
        play.PlayNextMusic();
    }
}
