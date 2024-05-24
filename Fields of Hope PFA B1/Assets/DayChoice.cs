using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Type
{
    Farm,
    Exploration
}

public class DayChoice : MonoBehaviour
{
    private DayManager _dayManager;
    private event Action OnChoose;

    private EventInstancier _eventInstancier;

    [Header("Boutons")]
    [SerializeField] private GameObject _farmButton;
    [SerializeField] private GameObject _explorationButton;

    private Vector3 _position;
    private static bool _selected;



    public void SelectFarm()
    {
        if(_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Farm;
            //OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            OnChooseDailyTask();
            Debug.Log($"<color=green>{_dayManager.DayChoice} </color>");
        }
    }

    public void SelectExploration()
    {
        if (_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Exploration;
            //OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            OnChooseDailyTask();
            Debug.Log($"<color=orange>{_dayManager.DayChoice} </color>");
        }
    }

    private void OnChooseDailyTask()
    {
        switch (_dayManager.DayChoice)
        {
            case DailyChoice.Farm:
                _selected = true;
                _farmButton.transform.DOLocalMoveX(_position.x - 150, 0.8f);
                _farmButton.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.8f);
                _farmButton.GetComponent<Button>().interactable = false;
                Destroy(_explorationButton);
                //_eventInstancier.InstantiateEvent();
                break;
            
            case DailyChoice.Exploration:
                _selected = true;
                _explorationButton.transform.DOLocalMoveX(_position.x + 150, 0.8f);
                _explorationButton.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.8f);
                _explorationButton.GetComponent<Button>().interactable = false;
                Destroy(_farmButton);
                _eventInstancier.InstantiateEvent();
                break;
        }
    }

    private void Start()
    {
        _eventInstancier = GameObject.Find("EventInstancier").GetComponent<EventInstancier>();
        _dayManager = GameObject.Find("DayManager").GetComponent<DayManager>();
        _position = this.transform.localPosition;
    }

    public void Restart()
    {
        _selected = false;
        this.transform.position = _position;
        this.transform.localScale = Vector3.one;
    }
}