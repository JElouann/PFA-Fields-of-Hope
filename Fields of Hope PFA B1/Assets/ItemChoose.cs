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

    public void ChooseVegetable()
    {
        chosenItem = PlantItem;
    }
    public void Validate(GameObject game)
    {
        InventoryEnum typeToChange = (chosenItem.Type != InventoryEnum.Medkit) ? InventoryEnum.Hunger : InventoryEnum.Life;
        statsManager.Regarde(typeToChange);
        if (!statsManager.CheckRessource(typeToChange)) return;
        print(statsManager.CheckRessource(typeToChange) + " | " + " LOLo");
        statsManager.ChangeValues(typeToChange, chosenItem.Satiété);
        statsManager.ChangeValues(chosenItem.Type, -1);
        game.SetActive(true);
    }

    public void Unchoose()
    {
        chosenItem = null;
    }
}
