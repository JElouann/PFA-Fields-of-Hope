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
            StartCoroutine(StartVideo());           
        }
    }

    public void Skip()
    {
        if (videoplayer)
        {
            videoplayer.Stop();
        }
    }

    private IEnumerator StartVideo()
    {
        videoplayer.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        ImageAnimation.SetActive(true);
        yield return new WaitForSecondsRealtime(10.5f);
        PanelText.SetActive(true);
        dialogue.StartDialogue("Au d�but du 21�me si�cle, WEST et EST sortent d'une longue guerre froide."+ "\n"+ "Ce conflit a caus� des tensions mondiales et une panique g�n�rale." + "\n" + "MID, fragilis�e par deux guerres mondiales, se trouve entre WEST et EST." + "\n" + "Pour �viter un nouveau conflit, MID cr�e le Comit� des Axes D�fensives (CAD)." + "\n" + "SUD, riche en ressources, attire l�attention mondiale." + "\n" + "En 2001, une attaque tue 3029 personnes dans WEST." + "\n" + "WEST accuse EST d�en �tre responsable via des mercenaires." + "\n" + "WEST envoie des troupes au SUD pour combattre le terrorisme, augmentant son influence." + "\n" + "EST, alli� de SUD, menace de riposter. Ce conflit id�ologique devient rapidement une guerre." + "\n" + "EST menace MID de frappes nucl�aires en raison de leur soutien � WEST." + "\n" + "Une r�union d�urgence du CAD diminue temporairement les tensions, mais MID et WEST renforcent les fronti�res autour d�EST." + "\n" + "EST lance un ultimatum et se pr�pare � se d�fendre." + "\n" + "Les combats �clatent. EST, voyant ses forces an�anties, lance une attaque nucl�aire sur MID." + "\n" + "Une contre-attaque massive suit." + "\n" + "Les capitales de WEST et d�EST sont d�truites, laissant les deux nations en ruines." + "\n" + "Les forces restantes de MID, WEST et EST se dispersent." + "\n" + "Le monde est en ruines." + "\n" + "Les survivants doivent naviguer dans ce paysage de d�solation." + "\n" + "Vous, joueur, devez survivre, reconstruire et apporter de l�espoir � un monde bris�.");
        yield return new WaitForSecondsRealtime(30f);
        MenuCin�matic.SetActive(false);
    }
}
