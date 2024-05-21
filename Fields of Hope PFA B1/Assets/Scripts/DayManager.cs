using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    private int _dayCounter;
    private StatsManager _statsManager;
    private EventInstancier _eventInstancier;

    [Header("Stats stuff")]
    [SerializeField][Tooltip("Represents how much food we loose each day")] private int FoodLoss;
    [field: SerializeField] public int FoodLossMultiplier { get; set; } = 1;

    [SerializeField][Tooltip("Represents how much life we loose each day")] private int LifeLoss;
    [field: SerializeField] public int LifeLossMultiplier { get; set; } = 1;

    [SerializeField] private TextMeshProUGUI _counterText;

    public void MoreFood() // TEST
    {
        _statsManager.ChangeValues("Hunger", 5);
    }

    public void NextDay()
    {
        OnEndDay();
        _dayCounter++;
        UpdateCounter();
    }

    private void OnEndDay()
    {
        // Jouer animation de changement de jour

        _statsManager.ChangeValues("Life", _statsManager.GetHungerConsequence());
        _statsManager.ChangeValues("Hunger", -FoodLoss * FoodLossMultiplier);
    }

    private void UpdateCounter()
    {
        _counterText.text = (_dayCounter).ToString();
    }

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
        _eventInstancier = GameObject.FindAnyObjectByType<EventInstancier>();
    }
}
