using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SeedsPlants : MonoBehaviour
{

    public SO_SeedsData seedData;

    [Serializable]
    public class InventorySlot
    {
        [field: SerializeField]
        public SO_SeedsData Plant { get; set; }

        [field: SerializeField]
        public int TempsRestantDePousse { get; set; }
    }

    public List<InventorySlot> InventorySlots;

    public void AddSeed()
    {
        InventorySlot yes = new InventorySlot();
        yes.Plant = seedData;
        yes.TempsRestantDePousse = seedData.TempsDePousseEnJours;
        InventorySlots.Add(yes);
    }

    public void RemoveDay()
    {
        foreach (InventorySlot slot in InventorySlots)
        {
            slot.TempsRestantDePousse--;
        }
    }

    public void RemoveSeed()
    {
        seedData = null;
    }
}
