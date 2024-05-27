using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class FarmManager : MonoBehaviour
{
    public GameObject PanelFarm;

    public SO_SeedsData seedData;

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
        Slot.Plant = seedData;
        Slot.TempsRestantDePousse = seedData.TempsDePousseEnJours;
        if (StatsManager.Seeds < Slot.Plant.CoutEnGraines)
        {
            Debug.Log("C'est Normal TQT");
        }
        else
        {
            StatsManager.ChangeValues(InventoryEnum.Seeds, -Slot.Plant.CoutEnGraines);
            InventorySlots.Add(Slot);
            GameObject.Find("EventInstancier").GetComponent<EventInstancier>().InstantiateEvent(EventType.Farm);
            PanelFarm.SetActive(false);
        }
    }

    public void RemoveDay()
    {
        if (InventorySlots == null) return;
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            GrowingPlant slot = InventorySlots[i];
            slot.TempsRestantDePousse--;
            if (slot.TempsRestantDePousse <= 0)
            {
                StatsManager.ChangeValues(slot.Plant.Type, 1);
                InventorySlots.Remove(slot);
            }
        }
    }

    public void RemoveSeed()
    {
        seedData = null;
    }
}
