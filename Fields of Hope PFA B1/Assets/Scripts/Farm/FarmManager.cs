using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantObjectTUTO selectPlant;
    public bool isPlanting = false;

    public void SelectPlant(PlantObjectTUTO newplant)
    {
        if(selectPlant == newplant)
        {
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            selectPlant = newplant;
            isPlanting = true;
        }
    }
}