using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndDayStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshProUGUI;

    [Serializable]
    public class StatChange
    {
        [field: SerializeField]
        public InventoryEnum inventory{ get; set; }

        [field: SerializeField]
        public int Amout { get; set; }
    }

    public List<StatChange> StatsHasChange;

    public void OnStatsChange(InventoryEnum inventoryEnum, int amout)
    {
        for (int i = 0; i < StatsHasChange.Count; i++)
        {
            if (StatsHasChange[i].inventory == inventoryEnum)
            {
                StatsHasChange[i].Amout += amout;
                m_TextMeshProUGUI.text += inventoryEnum + " "  + StatsHasChange[i].Amout.ToString();
                return;
            }
        }
    }

    public void OnDayFinished()
    {
        m_TextMeshProUGUI.text = null;
        for (int i = 0; i < StatsHasChange.Count; i++)
        {
            StatsHasChange[i].Amout = 0;
            gameObject.SetActive(false);
        }
    }
}
