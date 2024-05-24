using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectSeed : MonoBehaviour
{
    [SerializeField]
    private SO_SeedsData SO_SeedsData;

    [SerializeField]
    SeedsPlants seedsPlants;

    public TextMeshProUGUI textMeshProUGUI;

    public TextMeshProUGUI textDescription;

    public void SelectedSeed()
    {
        seedsPlants.seedData = SO_SeedsData;
        textDescription.text = SO_SeedsData.Description;
    }

    public void Start()
    {
        textMeshProUGUI.text = SO_SeedsData.Nom ;
    }
}
