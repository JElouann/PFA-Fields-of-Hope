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

    public void OnEndDay()
    {
        Destroy(_eventInstancier.CreatedEvent);
        print("ça marche");

        // Jouer animation de changement de jour

        // On met à jour les différentes valeurs
        _statsManager.ChangeValues(InventoryEnum.Life, _statsManager.GetHungerConsequence());
        //_statsManager.ChangeValues("Hunger", -FoodLoss * FoodLossMultiplier);
        _dayManager.DayChoice = DailyChoice.None;
    }
}
