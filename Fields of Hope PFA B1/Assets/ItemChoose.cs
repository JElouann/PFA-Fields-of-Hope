using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoose : MonoBehaviour
{
    [SerializeField]
    private StatsManager statsManager;

    public SO_SeedsData PlantItem;

    public InventoryEnum buttonItem;
    public static SO_SeedsData chosenItem;

    public void Manger(InventoryEnum inventoryEnum)
    {
        if (PlantItem.Type == inventoryEnum && statsManager.Medkit != 0 )
        {
            statsManager.ChangeValues(InventoryEnum.Life, PlantItem.Satiété);
            
        }
    } 

    public void ChooseVegetable()
    {
        chosenItem = PlantItem;
    }
    public void Validate()
    {
        InventoryEnum typeToChange = (chosenItem.Type != InventoryEnum.Medkit) ? InventoryEnum.Hunger : InventoryEnum.Life;
        if (!statsManager.CheckRessource(typeToChange)) return;
        statsManager.ChangeValues(typeToChange, chosenItem.Satiété);
    }

    public void Unchoose()
    {
        chosenItem = null;
    }
}
