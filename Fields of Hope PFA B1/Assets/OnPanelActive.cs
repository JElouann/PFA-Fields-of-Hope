using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnPanelActive : MonoBehaviour
{
    [SerializeField] Image Image;

    [SerializeField] TextMeshProUGUI TextNom;

    [SerializeField] TextMeshProUGUI TextDescription;

    [SerializeField] TextMeshProUGUI TextRendement;

    [SerializeField] TextMeshProUGUI TextQuantités;

    [SerializeField]
    ItemChoose ItemChoose;

    [SerializeField]
    StatsManager StatsManager;

    public void OnSetActive()
    {
        gameObject.SetActive(true);
        var b = ItemChoose.chosenItem;
        Image.overrideSprite = b.Image;
        TextNom.text = b.name;
        TextDescription.text = b.Description;
        TextQuantités.text = StatsManager._myStat[b.Type].ToString();
        TextRendement.text = "<color=#6FA048>" + "+" + b.Satiété.ToString() + "</color>"; ;
    }
}
