using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class FarmManager : MonoBehaviour
{
    public GameObject PanelFarm;

    public SO_SeedsData seedData;

    [SerializeField]
    private TextMeshProUGUI Text;

    [Serializable]
    public class GrowingPlant
    {
        [field: SerializeField]
        public SO_SeedsData Plant { get; set; }

        [field: SerializeField]
        public int TempsRestantDePousse { get; set; }
    }

    public List<GrowingPlant> InventorySlots;

    [SerializeField]
    private StatsManager StatsManager;

    public void AddSeed()
    {
        GrowingPlant Slot = new GrowingPlant();
        if (seedData == null) return;
        Slot.Plant = seedData;
        Slot.TempsRestantDePousse = seedData.TempsDePousseEnJours;
        if (StatsManager.Seeds < Slot.Plant.CoutEnGraines) return;
        StatsManager.ChangeValues(InventoryEnum.Graines, -Slot.Plant.CoutEnGraines, true);
        InventorySlots.Add(Slot);
        GameObject.Find("EventInstancier").GetComponent<EventInstancier>().InstantiateEvent(EventType.Farm);
        PanelFarm.SetActive(false);
    }

    public void RemoveDay()
    {
        if (InventorySlots.Count == 0) { Debug.Log("TG"); }
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            GrowingPlant slot = InventorySlots[i];
            slot.TempsRestantDePousse--;
            if (slot.TempsRestantDePousse <= 0)
            {
                StatsManager.ChangeValues(slot.Plant.Type, 1, true);
                InventorySlots.Remove(slot);
                i--;
            }
        }
    }

    public void AddDay()
    {
        if (InventorySlots == null) return;
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            GrowingPlant slot = InventorySlots[i];
            slot.TempsRestantDePousse++;
        }
    }

    public void RemoveSeed()
    {
        seedData = null;
        GameObject.Find("EventInstancier").GetComponent<EventInstancier>().InstantiateEvent(EventType.Farm);
        PanelFarm.SetActive(false);
    }

    public void ShowListPlant()
    {
        
        Text.text = string.Empty;
        if (InventorySlots.Count == 0)
        {
            Text.text = "Je n'ai rien planter, peut-être que je devrais m'y mettre.";
        }
        else
        {
            for (int i = 0; i < InventorySlots.Count; i++)
            {
                GrowingPlant slot = InventorySlots[i];
                Text.text += slot.Plant.name + " Temps Restants : " + slot.TempsRestantDePousse + "\n";
            }
        }
    }
}
