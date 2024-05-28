using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoose : MonoBehaviour
{
    [SerializeField]
    private StatsManager statsManager;

    public SO_SeedsData PlantItem;

    public void Selected(SO_SeedsData item)
    {
        PlantItem = item;
    }

    public void Deselected()
    {
        Selected(null);
    }

    public void Manger(GameObject game1)
    {
        if (PlantItem.Type == InventoryEnum.Medkit && statsManager.Medkit != 0 )
        {
            statsManager.ChangeValues(InventoryEnum.Life, PlantItem.Sati�t�);
            game1.SetActive(true);
        }
        else if (PlantItem.Type == InventoryEnum.Carotte)
        {
            statsManager.ChangeValues(InventoryEnum.Hunger, PlantItem.Sati�t�);
        }
        else
        {

        }
    } 
}
