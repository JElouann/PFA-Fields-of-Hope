using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

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
        InventoryEnum typeToChange = (chosenItem.Type != InventoryEnum.KitDeSoins) ? InventoryEnum.Faim : InventoryEnum.Santé;
        Debug.Log(statsManager._myStat[chosenItem.Type]);
        if (!statsManager.CheckRessource(chosenItem.Type)) return;
        statsManager.ChangeValues(typeToChange, chosenItem.Satiété);
        statsManager.ChangeValues(chosenItem.Type, -1, true);
        game.SetActive(true);
    }

    public void Unchoose()
    {
        chosenItem = null;
    }
}
