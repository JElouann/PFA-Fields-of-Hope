using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{

    [SerializeField]
    private EndDayStats EndDayStats;

    public int _dayCounter { get; set; }
    public StatsManager _statsManager { get; private set; }
    public EventInstancier _eventInstancier { get; private set; }

    [field: SerializeField]
    public DayChoice DayChoiceScript { get; set; }

    public DailyChoice DayChoice { get; set; }

    [field: SerializeField] public EndDay EndDay { get; private set; }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _counterText;

    [Header("Stats stuff")]
    [SerializeField][Tooltip("Represents how much food we loose each day")] private int FoodLoss;
    [SerializeField][Tooltip("Represents how much life we loose each day")] private int LifeLoss;

    #region DEV CHEAT
    public void MoreLife() // DEV
    {
        _statsManager.ChangeValues(InventoryEnum.Santé, 5);
    }

    public void MoreFood() // DEV
    {
        _statsManager.ChangeValues(InventoryEnum.Faim, 5);
    }

    public void MoreSeeds() // DEV
    {
        _statsManager.ChangeValues(InventoryEnum.Graines, 5);
    }
    #endregion

    public async void NextDay()
    {
        FindAnyObjectByType<TimePostProcessHandler>()._specialProcess = StartCoroutine(FindAnyObjectByType<TimePostProcessHandler>().NightFall());
        await Task.Delay(4000);
        DayChoice = DailyChoice.None;
        DayChoiceScript.Restart();
        _dayCounter++;
        _eventInstancier._eventsPassed.ToList().ForEach(e => _eventInstancier._eventsPassed[e.Key]--);
        _counterText.text = (_dayCounter).ToString();
        DayChoice = DailyChoice.None;
        EndDayStats.OnDayFinished();
    }


    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
        _eventInstancier = GameObject.FindAnyObjectByType<EventInstancier>();
    }

    public void UpdateTextDay()
    {
        _counterText.text = _dayCounter.ToString();
    }
}
