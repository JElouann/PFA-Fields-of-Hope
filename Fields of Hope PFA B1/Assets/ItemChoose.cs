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
        Debug.Log(statsManager._myStat[chosenItem.Type]);
        if (!statsManager.CheckRessource(chosenItem.Type)) return;
        statsManager.ChangeValues(typeToChange, chosenItem.Sati�t�);
        statsManager.ChangeValues(chosenItem.Type, -1);
        Debug.Log(statsManager._myStat[chosenItem.Type]);
        game.SetActive(true);
    }

    public void Unchoose()
    {
        chosenItem = null;
    }
}
