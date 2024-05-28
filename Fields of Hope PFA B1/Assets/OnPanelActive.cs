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

    [SerializeField]
    ItemChoose ItemChoose;

    public void OnSetActive()
    {
        gameObject.SetActive(true);
        var b = ItemChoose.PlantItem;
        Image.overrideSprite = b.Image;
        TextNom.text = b.name;
        TextDescription.text = b.Description;
        TextRendement.text = b.Satiété.ToString();
    }
}
