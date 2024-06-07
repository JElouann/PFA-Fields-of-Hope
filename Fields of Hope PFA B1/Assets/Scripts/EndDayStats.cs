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
        public int Amount { get; set; }
    }

    public List<StatChange> StatsHasChange;

    public void OnStatsChange(InventoryEnum inventoryEnum, int amout)
    {
        for (int i = 0; i < StatsHasChange.Count; i++)
        {
            if (StatsHasChange[i].inventory == inventoryEnum)
            {
                StatsHasChange[i].Amount += amout;
                return;
            }
        }
    }

    public void OnEndDayToString()
    {
        for(int i = 0;i < StatsHasChange.Count; i++)
        {
            if (StatsHasChange[i].Amount != 0)
            {
                string stats = (StatsHasChange[i].Amount < 0) ? "<color=#D14E4E>" + StatsHasChange[i].Amount.ToString() + "</color>" :
                                                                "<color=#6FA048>" + "+" + StatsHasChange[i].Amount.ToString() + "</color>";
                m_TextMeshProUGUI.text += StatsHasChange[i].inventory + " " + stats + "\n";
            }
        }
    }

    public void OnDayFinished()
    {
        m_TextMeshProUGUI.text = null;
        for (int i = 0; i < StatsHasChange.Count; i++)
        {
            StatsHasChange[i].Amount = 0;
        }
    }
}
