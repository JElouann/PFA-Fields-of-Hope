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
        print("�a marche");

        // Jouer animation de changement de jour

        // On met � jour les diff�rentes valeurs
        _statsManager.ChangeValues(InventoryEnum.Life, _statsManager.GetHungerConsequence());
        //_statsManager.ChangeValues("Hunger", -FoodLoss * FoodLossMultiplier);
        _dayManager.DayChoice = DailyChoice.None;
    }
}
