using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstancier : MonoBehaviour
{
    // Composant requis
    private StatsManager _statsManager;

    [SerializeField]
    private Transform _where;

    // New version
    private List<SO_Events> _eventDatasSuitable = new();
    private List<SO_Events> _eventsPassed = new();
    
    [SerializeField]
    private GameObject _eventPrefabBasis;

    [SerializeField]
    private List<SO_Events> _eventDatas; // /!\ SEPARER EN DEUX : events explo et events ferme


    public void InstantiateEvent()
    {
        CreateSuitableEventDataList();
        InitializeEvent(_where);
    }

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
    }

    private void Start() // TEMPORARY
    {
        //InstantiateEvent();
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
        if (!(checkedEvent.OufitudePool.Minimum > degreToCompare | checkedEvent.OufitudePool.Maximum < degreToCompare))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Creates a GameObject event from a prefab basis, assignes to it the chosen event and reload it
    private void InitializeEvent(Transform where)
    {
        int selectedEventIndexDATA = Random.Range(0, _eventDatasSuitable.Count);

        GameObject createdEvent = Instantiate(_eventPrefabBasis, where);
        EventScript createdEventScript = createdEvent.GetComponent<EventScript>(); // get the EventScript of the new event GameObject

        // update the event contained in the new event GameObject, then load it to display it and update its script
        createdEventScript.currentEvent = _eventDatasSuitable[selectedEventIndexDATA];
        createdEventScript.LoadThis();
        _eventsPassed.Add(createdEventScript.currentEvent);
        _eventDatasSuitable.Clear();
    }
}
