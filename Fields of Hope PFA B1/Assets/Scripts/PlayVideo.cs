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
    private GameObject MenuCinématic;

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
        dialogue.StartDialogue("Au début du 21ème siècle, WEST et EST sortent d'une longue guerre froide."+ "\n"+ "Ce conflit a causé des tensions mondiales et une panique générale." + "\n" + "MID, fragilisée par deux guerres mondiales, se trouve entre WEST et EST." + "\n" + "Pour éviter un nouveau conflit, MID crée le Comité des Axes Défensives (CAD)." + "\n" + "SUD, riche en ressources, attire l’attention mondiale." + "\n" + "En 2001, une attaque tue 3029 personnes dans WEST." + "\n" + "WEST accuse EST d’en être responsable via des mercenaires." + "\n" + "WEST envoie des troupes au SUD pour combattre le terrorisme, augmentant son influence." + "\n" + "EST, allié de SUD, menace de riposter. Ce conflit idéologique devient rapidement une guerre." + "\n" + "EST menace MID de frappes nucléaires en raison de leur soutien à WEST." + "\n" + "Une réunion d’urgence du CAD diminue temporairement les tensions, mais MID et WEST renforcent les frontières autour d’EST." + "\n" + "EST lance un ultimatum et se prépare à se défendre." + "\n" + "Les combats éclatent. EST, voyant ses forces anéanties, lance une attaque nucléaire sur MID." + "\n" + "Une contre-attaque massive suit." + "\n" + "Les capitales de WEST et d’EST sont détruites, laissant les deux nations en ruines." + "\n" + "Les forces restantes de MID, WEST et EST se dispersent." + "\n" + "Le monde est en ruines." + "\n" + "Les survivants doivent naviguer dans ce paysage de désolation." + "\n" + "Vous, joueur, devez survivre, reconstruire et apporter de l’espoir à un monde brisé.");
        yield return new WaitForSecondsRealtime(30f);
        MenuCinématic.SetActive(false);
    }
}
