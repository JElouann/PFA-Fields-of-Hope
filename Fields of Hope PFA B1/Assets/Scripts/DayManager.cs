using System;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{

    public int _dayCounter { get; set; }
    public StatsManager _statsManager { get; private set; }
    public EventInstancier _eventInstancier { get; private set; }

    public DailyChoice DayChoice { get; set; }

    [field: SerializeField] public EndDay EndDay { get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _counterText;

    [Header("Stats stuff")]
    [SerializeField][Tooltip("Represents how much food we loose each day")] private int FoodLoss;
    [SerializeField][Tooltip("Represents how much life we loose each day")] private int LifeLoss;
    

    public event Action OnEndDay;

    #region DEV CHEAT
    public void MoreFood() // DEV
    {
        _statsManager.ChangeValues(InventoryEnum.Life, 5);
    }

    public void MoreSeeds() // DEV
    {
        _statsManager.ChangeValues(InventoryEnum.Seeds, 5);
    }
    #endregion

    public void NextDay()
    {
        OnEndDay?.Invoke();
        _dayCounter++;
        _counterText.text = (_dayCounter).ToString();
    }


    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
        _eventInstancier = GameObject.FindAnyObjectByType<EventInstancier>();
        OnEndDay += EndDay.OnEndDay;
    }
}
