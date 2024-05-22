using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{

    public int _dayCounter { get; private set; }
    private StatsManager _statsManager;
    private EventInstancier _eventInstancier;
    public DailyChoice DayChoice { get; set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _counterText;

    [Header("Stats stuff")]
    [SerializeField][Tooltip("Represents how much food we loose each day")] private int FoodLoss;
    [SerializeField][Tooltip("Represents how much life we loose each day")] private int LifeLoss;
    [field: Header("Difficulty multipliers")]
    [field: SerializeField] public int LifeLossMultiplier { get; set; } = 1;
    [field: SerializeField] public int FoodLossMultiplier { get; set; } = 1;

    public void MoreFood() // DEV
    {
        _statsManager.ChangeValues("Hunger", 5);
    }

    public void NextDay()
    {
        OnEndDay();
        _dayCounter++;
        _counterText.text = (_dayCounter).ToString();
    }

    private void OnEndDay()
    {
        // Jouer animation de changement de jour

        // On met à jour les différentes valeurs
        _statsManager.ChangeValues("Life", _statsManager.GetHungerConsequence());
        _statsManager.ChangeValues("Hunger", -FoodLoss * FoodLossMultiplier);
        DayChoice = DailyChoice.None;
    }

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
        _eventInstancier = GameObject.FindAnyObjectByType<EventInstancier>();
    }
}
