using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Histoire
{
    public List<SO_Events> List;
}

public class EventInstancier : MonoBehaviour
{
    // Scripts requis
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private DayManager _dayManager;
    private StoryHandler _storyHandler;

    // Socket représentant la position où instancier les events
    [SerializeField]
    private Transform _position;
    
    // Prefab utilisé pour instancier les events (gameobjects) à partir de leurs Datas
    [SerializeField]
    private GameObject _eventPrefabBasis;

    // Listes utilisées pour stocker et choisir les events
    private List<SO_Events> _eventDatasSuitable = new();
    private Dictionary<SO_Events, int> _eventsPassed = new();

    // Listes contenant tous les events, par type
    [SerializeField]
    private List<SO_Events> _farmEventDatas;
    [SerializeField]
    private List<SO_Events> _expeditionEventDatas;

    // Event créé
    [field: SerializeField]
    public GameObject CreatedEvent { get; set; }

    public void InstantiateEvent(EventType eventType)
    {
        if (_storyHandler.IsStoryEventToday())
        {
            print("STORY TODAY");
            InitializeEvent(_storyHandler.GetRandomStoryEvent(), _position);
        }
        else if (eventType == EventType.Expedition)
        {
            CreateSuitableExpeditionEventList();
            InitializeEvent(null, _position);
        }
        else
        {
            CreateSuitableFarmEventList();
            InitializeEvent(null, _position);
        }
    }

    // Creates a list with every suitable farm events for this oufitude degre
    private void CreateSuitableFarmEventList()
    {
        int degreDeOufitude = _statsManager.OufitudeDegre;
        foreach (SO_Events eventData in _farmEventDatas)
        {
            if (IsInOufitudeRange(eventData, degreDeOufitude))
            {
                _eventDatasSuitable.Add(eventData);
            }
        }
    }

    // Creates a list with every expedition suitable events for this oufitude degre
    private void CreateSuitableExpeditionEventList()
    {
        int degreDeOufitude = _statsManager.OufitudeDegre;
        foreach (SO_Events eventData in _expeditionEventDatas)
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
    private void InitializeEvent(SO_Events toInitialize, Transform where)
    {
        int selectedEventIndex = UnityEngine.Random.Range(0, _eventDatasSuitable.Count);
            
        CreatedEvent = Instantiate(_eventPrefabBasis, where);
        EventScript createdEventScript = CreatedEvent.GetComponent<EventScript>(); // Get the EventScript of the new event GameObject

        // Update the event contained in the new event GameObject, then load it to display it and update its script

        createdEventScript.currentEvent = (toInitialize == null) ? _eventDatasSuitable[selectedEventIndex] : toInitialize;

        createdEventScript.OnEndEvent += _dayManager.EndDay.OnEndDay;
        createdEventScript.LoadThis();
        _eventsPassed.Add(createdEventScript.currentEvent);
        _eventDatasSuitable.Clear();
    }

    private void Awake()
    {
        _storyHandler = GetComponent<StoryHandler>();
    }
}
