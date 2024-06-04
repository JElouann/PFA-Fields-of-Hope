using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField]
    private GameObject PanelText;

    [SerializeField]
    private DialogueBox dialogue;

    [SerializeField] 
    private GameObject MenuCin�matic;

    [SerializeField]
    GameObject ImageAnimation;

    [SerializeField]
    private VideoPlayer videoplayer;


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
        if (videoplayer)
        {
            videoplayer.Stop();
            PanelText.SetActive(false);
            MenuCin�matic.SetActive(false);
        }
    }

    private IEnumerator StartVideo()
    {
        videoplayer.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        ImageAnimation.SetActive(true);
        yield return new WaitForSecondsRealtime(10.5f);
        PanelText.SetActive(true);
        dialogue.StartDialogue("Au d�but du 21�me si�cle, une attaque terroriste d�clenche une guerre entre les puissances mondiales WEST et EST, entra�nant des frappes nucl�aires d�vastatrices. ");
        yield return new WaitForSecondsRealtime(10f);
        dialogue.StartDialogue("Les nations sont en ruines et les survivants doivent naviguer dans un monde post-apocalyptique.");
        yield return new WaitForSecondsRealtime(10f);
        dialogue.StartDialogue("Vous, joueur, devez survivre, reconstruire et apporter de l�espoir � ce monde bris�.");
        yield return new WaitForSecondsRealtime(10f);
        PanelText.SetActive(false);
        MenuCin�matic.SetActive(false);
    }
}
