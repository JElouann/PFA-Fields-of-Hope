using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum Type
{
    Farm,
    Exploration
}

public class DayChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private DayManager _dayManager;
    private event Action OnChoose;

    private EventInstancier _eventInstancier;

    [Header("Boutons")]
    [SerializeField] private GameObject _farmButton;
    [SerializeField] private GameObject _explorationButton;

    [Header("Gamefeel")]
    [SerializeField] private Vector3 _scaleOnHover;
    [SerializeField] private float _scaleOnHoverSpeed;
    [SerializeField] private float _unscaleSpeed;
    private Vector3 _position;
    private static bool _selected;

    [Space(5)]
    [SerializeField] private float _slideValue;
    [SerializeField] private Type _type;

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
        float _slideDirection = _type == Type.Farm ? -1 : 1;
        switch (_dayManager.DayChoice)
        {
            case DailyChoice.Farm:
                Destroy(_explorationButton);
                _eventInstancier.InstantiateEvent();
                break;
            
            case DailyChoice.Exploration:
                this.transform.DOLocalMoveX(_position.x + _slideDirection, 0.8f);
                Destroy(_farmButton);
                _eventInstancier.InstantiateEvent();
                break;
        }
    }

    private void Start()
    {
        _eventInstancier = GameObject.Find("EventInstancier").GetComponent<EventInstancier>();
        _dayManager = GameObject.Find("DayManager").GetComponent<DayManager>();

        OnChoose += OnChooseDailyTask;
        _position = this.transform.localPosition;
    }

    #region GameFeel
    public void OnPointerEnter(PointerEventData eventData)
    {
        float _slideDirection = _type == Type.Farm ? -1 : 1;
        this.transform.SetAsLastSibling();
        this.transform.DOScale(_scaleOnHover, _scaleOnHoverSpeed);
        this.transform.DOLocalMoveX(_position.x + _slideDirection * _slideValue, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        float _returnDirection = _type == Type.Exploration ? 1 : -1;
        this.transform.DOScale(Vector3.one, _unscaleSpeed);
        this.transform.DOLocalMoveX(_position.x, 0.3f);
    }
    #endregion
}
