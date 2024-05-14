using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    private int _dayCounter;
    private StatsManager _statsManager;
    private EventInstancier _eventInstancier;

    [Header("Stats stuff")]
    [SerializeField][Tooltip("Represents how much food we loose each day")] private int FoodLoss;
    [field: SerializeField] public int FoodLossMultiplier { get; set; }
    [SerializeField][Tooltip("Represents how much life we loose each day")] private int LifeLoss;
    [field: SerializeField] public int LifeLossMultiplier { get; set; }

    public void NextDay()
    {
        _dayCounter++;
    }

    private void OnEndDay()
    {

    }

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
        _eventInstancier = GameObject.FindAnyObjectByType<EventInstancier>();
    }
}
