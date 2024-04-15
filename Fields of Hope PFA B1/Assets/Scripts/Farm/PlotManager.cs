using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    private bool isPlanted = false;
    public SpriteRenderer plant;

    private int plantStage = 0;
    private float timer;

    private PlantObjectTUTO PlantObjectTUTO;
    private PlantObjectTUTO test;
    private FarmManager FarmManager;

    private void Start()
    {
        FarmManager = transform.parent.GetComponent<FarmManager>();
    }

    private void Update()
    {

    }

    public void GrowthPlant()
    {
        if (isPlanted && test != null)
        {
            if (plantStage < test.plantStages.Length - 1)
            {
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if(plantStage == test.plantStages.Length - 1 )
            {
                Harvest();
            }
        }
        else if (FarmManager.plantItem.NB_graines != 0)
        {
            Plant(FarmManager.selectPlant);
        }
    }

    private void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    private void Plant(PlantObjectTUTO newplant)
    {
        test = newplant;
        if (test != null)
        {
            FarmManager.selectPlant = null;
            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            timer = test.timeBtwStages;
            plant.gameObject.SetActive(true);
            FarmManager.plantItem.NB_graines--;
        }
    }

    private void UpdatePlant()
    {
        plant.sprite = test.plantStages[plantStage];
    }
}