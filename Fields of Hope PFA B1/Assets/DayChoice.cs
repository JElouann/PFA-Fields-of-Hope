using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class DayChoice : MonoBehaviour
{
    private DayManager _dayManager;
    private event Action OnChoose;

    [SerializeField] private GameObject FarmPanel;
    [SerializeField] private GameObject ExplorationPanel;

    private EventInstancier _eventInstancier;

    public void SelectFarm()
    {
        if(_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Farm;
            OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            Debug.Log($"<color=#C4D165>{_dayManager.DayChoice} </color>");
        }
    }

    public void SelectExploration()
    {
        if (_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Exploration;
            OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            Debug.Log($"<color=#D1AC65>{_dayManager.DayChoice} </color>");
        }
    }

    private void OnChooseDailyTask()
    {
        switch(_dayManager.DayChoice)
        {
            case DailyChoice.Farm:
                FarmPanel.SetActive(true);
                _eventInstancier.InstantiateEvent();
                break;
            
            case DailyChoice.Exploration:
                ExplorationPanel.SetActive(true);
                _eventInstancier.InstantiateEvent();
                break;
        }
    }

    private void Start()
    {
        _eventInstancier = GameObject.Find("EventInstancier").GetComponent<EventInstancier>();
        _dayManager = GameObject.Find("DayManager").GetComponent<DayManager>();

        OnChoose += OnChooseDailyTask;
        FarmPanel.SetActive(false);
        ExplorationPanel.SetActive(false);
    }
}
