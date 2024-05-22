using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DayChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private DayManager _dayManager;
    private event Action OnChoose;

    [SerializeField] private GameObject FarmPanel;
    [SerializeField] private GameObject ExplorationPanel;

    private EventInstancier _eventInstancier;

    [Header("Gamefeel")]
    [SerializeField] private Vector3 _scaleOnHover;
    [SerializeField] private float _scaleOnHoverSpeed;
    [SerializeField] private float _unscaleSpeed;

    public void SelectFarm()
    {
        if(_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Farm;
            OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            Debug.Log($"<color=green>{_dayManager.DayChoice} </color>");
        }
    }

    public void SelectExploration()
    {
        if (_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Exploration;
            OnChoose?.Invoke(); // invoke C# event responsible of instancing event
            Debug.Log($"<color=orange>{_dayManager.DayChoice} </color>");
        }
    }

    private void OnChooseDailyTask()
    {
        switch(_dayManager.DayChoice)
        {
            case DailyChoice.Farm:
                //Destroy(gameObject);
                //FarmPanel.SetActive(true);
                _eventInstancier.InstantiateEvent();
                break;
            
            case DailyChoice.Exploration:
                //ExplorationPanel.SetActive(true);
                _eventInstancier.InstantiateEvent();
                break;
        }
    }

    private void Start()
    {
        _eventInstancier = GameObject.Find("EventInstancier").GetComponent<EventInstancier>();
        _dayManager = GameObject.Find("DayManager").GetComponent<DayManager>();

        OnChoose += OnChooseDailyTask;
        //FarmPanel.SetActive(false);
        //ExplorationPanel.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();
        this.transform.DOScale(_scaleOnHover, _scaleOnHoverSpeed);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.DOScale(Vector3.one, _unscaleSpeed);
    }
}
