using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject plantItem;
    List<PlantObjectTUTO> plantObjects = new List<PlantObjectTUTO>();

    private void Awake()
    {
        //Assets/Resources/Plants
        var loadPlants = Resources.LoadAll("Plants", typeof(PlantObjectTUTO));
        foreach (var plant in loadPlants)
        {
            plantObjects.Add((PlantObjectTUTO)plant);
        }
        plantObjects.Sort(SortByPrice);

        foreach (var plant in plantObjects)
        {
            PlantItem newPlant = Instantiate(plantItem, transform).GetComponent<PlantItem>();
            newPlant.plant = plant;
        }
    }

    int SortByPrice(PlantObjectTUTO plantObject1, PlantObjectTUTO plantObject2)
    {
        return plantObject1.buyPrice.CompareTo(plantObject2.buyPrice);
    }

    int SortByTime(PlantObjectTUTO plantObject1, PlantObjectTUTO plantObject2)
    {
        return plantObject1.timeBtwStages.CompareTo(plantObject2.timeBtwStages);
    }
}