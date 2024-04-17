using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObjectTUTO plant;

    public TextMeshProUGUI nameTxt;
    public Image icon;
    public Image btnImage;
    public TextMeshProUGUI btnTxt;
    public TextMeshProUGUI Nb_Graines;

    public int NB_graines;

    private FarmManager fm;

    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void SelectSeedsWanted()
    {
        fm.SelectPlant(plant, NB_graines, this);
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        icon.sprite = plant.icon;
    }

    private void Update()
    {
        Nb_Graines.text = NB_graines.ToString();
    }
}
