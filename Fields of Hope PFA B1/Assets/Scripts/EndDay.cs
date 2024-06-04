using System.Collections;
using System.Collections.Generic;
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
        Destroy(_eventInstancier.CreatedEvent);
        print("ça marche");

        // Jouer animation de changement de jour

        // On met a jour les diff�rentes valeurs

        _statsManager.ChangeValues(InventoryEnum.Santé, _statsManager.GetHungerConsequence(), false);
        _statsManager.ChangeValues(InventoryEnum.Faim, -_foodLoss * _foodLossMultiplier, false);
        
        _dayManager.DayChoice = DailyChoice.None;

        _dayManager.DayChoiceScript.Restart();
        SeedsPlants.RemoveDay();

        
        PanelEndDay.SetActive(true);
        EndDayStats.OnEndDayToString();
    }
}