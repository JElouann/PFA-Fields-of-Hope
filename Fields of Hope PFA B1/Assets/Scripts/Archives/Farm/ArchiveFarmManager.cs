using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveFarmManager : MonoBehaviour
{
    public PlantObjectTUTO selectPlant;
    public bool isPlanting = false;

    public bool isSelecting = false;
    public int selectedTool = 0;

    [HideInInspector]
    public PlantItem plantItem;

    public void SelectPlant(PlantObjectTUTO newplant, int nb, PlantItem plant)
    {
        if(selectPlant == newplant)
        {
            selectPlant = null;
            isPlanting = false;
            plantItem = null;
        }
        else
        {
            selectPlant = newplant;
            isPlanting = true;
            plantItem = plant;
        }
    }
}