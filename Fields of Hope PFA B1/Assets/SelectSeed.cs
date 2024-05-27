using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectSeed : MonoBehaviour
{
    public SO_SeedsData SO_SeedsData;

    [SerializeField]
    FarmManager seedsPlants;

    public Image Image;

    public TextMeshProUGUI textDescription;

    public void SelectedSeed()
    {
        seedsPlants.seedData = SO_SeedsData;
        textDescription.text = SO_SeedsData.Description;
    }

    public void Start()
    {
        Image.sprite = SO_SeedsData.Image ;
    }
}
