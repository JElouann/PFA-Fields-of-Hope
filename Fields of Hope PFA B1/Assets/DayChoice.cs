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

    public void SelectFarm()
    {
        if(_dailyChoice == DailyChoice.None)
        {
            _dailyChoice = DailyChoice.Farm;
            // invoke C# event responsible of instancing event
            print(_dailyChoice.ToString());
        }
    }

    public void SelectExploration()
    {
        if (_dailyChoice == DailyChoice.None)
        {
            _dailyChoice = DailyChoice.Exploration;
            // invoke C# event responsible of instancing event
            print(_dailyChoice.ToString());
        }
    }
}
