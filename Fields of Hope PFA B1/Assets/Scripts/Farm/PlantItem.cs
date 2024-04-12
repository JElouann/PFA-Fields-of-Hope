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

    private FarmManager fm;

    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant()
    {
        fm.SelectPlant(plant);
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        icon.sprite = plant.icon;
    }
}
