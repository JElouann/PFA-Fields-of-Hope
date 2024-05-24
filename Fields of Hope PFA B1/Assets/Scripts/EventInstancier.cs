using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstancier : MonoBehaviour
{
    // Managers requis
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private DayManager _dayManager;

    // Socket repr�sentant la position o� instancier les events
    [SerializeField]
    private Transform _where;
    
    // Prefab utilis� pour instancier les events (gameobjects) � partir de leurs Datas
    [SerializeField]
    private GameObject _eventPrefabBasis;

    // Listes utilis�es pour stocker et choisir les events
    private List<SO_Events> _eventDatasSuitable = new();
    private List<SO_Events> _eventsPassed = new();

    [SerializeField]
    private List<SO_Events> _eventDatas; // /!\ SEPARER EN DEUX : events explo et events ferme

    [SerializeField]
    private List<SO_Events> _farmEventDatas;

    [SerializeField]
    private List<SO_Events> _expeditionEventDatas;

    [SerializeField]
    private List<SO_Events> _histoireEventDatas;

    [field: SerializeField]
    public GameObject CreatedEvent { get; set; }

    public void InstantiateEvent()
    {
        CreateSuitableEventDataList();
        InitializeEvent(_where);
    }

    private void Awake()
    {
        //_statsManager = GameObject.FindAnyObjectByType<StatsManager>();
    }

    // New version, where we create GameObjects from event datas to avoid creating prefabs for each events

    // Creates a list with every suitable events for this oufitude degre
    private void CreateSuitableEventDataList() 
    {
        int degreDeOufitude = _statsManager.OufitudeDegre;

        foreach (SO_Events eventData in _eventDatas)
        {
            if (IsInOufitudeRange(eventData, degreDeOufitude))
            {
                _eventDatasSuitable.Add(eventData);
            }
        }
    }

    // Checks if the event range fits with the Oufitude degre
    private bool IsInOufitudeRange(SO_Events checkedEvent, int degreToCompare)
    {
        bool toReturn = !(checkedEvent.OufitudePool.Minimum > degreToCompare | checkedEvent.OufitudePool.Maximum < degreToCompare) ? true : false;
        return toReturn;
    }

    // Creates a GameObject event from a prefab basis, assignes to it the chosen event and reload it
    private void InitializeEvent(Transform where)
    {
        int selectedEventIndexDATA = Random.Range(0, _eventDatasSuitable.Count);

        CreatedEvent = Instantiate(_eventPrefabBasis, where);
        EventScript createdEventScript = CreatedEvent.GetComponent<EventScript>(); // get the EventScript of the new event GameObject

        // update the event contained in the new event GameObject, then load it to display it and update its script
        createdEventScript.currentEvent = _eventDatasSuitable[selectedEventIndexDATA];
        createdEventScript.OnEndEvent += _dayManager.EndDay.OnEndDay;
        createdEventScript.LoadThis();
        _eventsPassed.Add(createdEventScript.currentEvent);
        _eventDatasSuitable.Clear();
    }
}
