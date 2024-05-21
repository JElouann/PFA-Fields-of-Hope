using System;
using UnityEngine;

public enum DailyChoice
{
    None,
    Farm,
    Exploration
}

public class DayChoice : MonoBehaviour
{
    private DailyChoice _dailyChoice;
    private event Action OnChoose;

    [SerializeField] private GameObject FarmPanel;
    [SerializeField] private GameObject ExplorationPanel;

    public void SelectFarm()
    {
        if(_dailyChoice == DailyChoice.None)
        {
            _dailyChoice = DailyChoice.Farm;
            OnChoose?.Invoke(); // invoke C# event responsible of instancing event

            print(_dailyChoice.ToString());
        }
    }

    public void SelectExploration()
    {
        if (_dailyChoice == DailyChoice.None)
        {
            _dailyChoice = DailyChoice.Exploration;
            OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            print(_dailyChoice.ToString());
        }
    }

    private void OnChooseDailyTask()
    {
        if (_dailyChoice == DailyChoice.Farm)
        {

        }

        if (_dailyChoice == DailyChoice.Exploration)
        {

        }
    }

    private void Start()
    {
        OnChoose += OnChooseDailyTask;
    }
}
