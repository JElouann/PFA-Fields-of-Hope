using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    [SerializeField]
    private DayManager _dayManager;
    [SerializeField]
    private StatsManager _statsManager;
    [SerializeField]
    private EventInstancier _eventInstancier;
    [SerializeField]
    private int _foodLoss;
    [SerializeField]
    private int _foodLossMultiplier;

    [SerializeField]
    private FarmManager SeedsPlants;

    [SerializeField]
    private GameObject PanelEndDay;

    [SerializeField]
    private EndDayStats EndDayStats;

    public void OnEndDay()
    {
        PanelEndDay.SetActive(true);
        EndDayStats.OnEndDayToString();

        Destroy(_eventInstancier.CreatedEvent);

        _statsManager.ChangeValues(InventoryEnum.Santé, _statsManager.GetHungerConsequence());
        _statsManager.ChangeValues(InventoryEnum.Faim, -_foodLoss * _foodLossMultiplier);
        
        
        //SeedsPlants.RemoveDay();
        SeedsPlants.ShowListPlant();
        
    }
}
