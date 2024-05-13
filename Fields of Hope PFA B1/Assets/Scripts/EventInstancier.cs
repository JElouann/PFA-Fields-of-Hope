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
    
    [SerializeField]
    private GameObject _eventPrefabBasis;

    [SerializeField]
    private List<SO_Events> _eventDatas;

    // Previous version
    //private List<GameObject> _eventsSuitable = new();
    //[SerializeField]
    //private List<GameObject> _eventPrefabs;

    private void Start()
    {
        CreateSuitableEventDataList();
        InstantiateEventFromData(_where);
    }

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
    }

    // New version, where we create GameObjects from event datas to avoid creating prefabs for each events

    // Creates a list with every suitable events for this oufitude degre
    private void CreateSuitableEventDataList() 
    {
        int degreDeOufitude = _statsManager.OufitudeDegre;

        foreach (SO_Events eventData in _eventDatas)
        {
            if (IsDataInOufitudeRange(eventData, degreDeOufitude))
            {
                _eventDatasSuitable.Add(eventData);
            }
        }
    }

    // Checks if the event range fits with the Oufitude degre
    private bool IsDataInOufitudeRange(SO_Events checkedEvent, int degreToCompare)
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
    private void InstantiateEventFromData(Transform where)
    {
        int selectedEventIndexDATA = Random.Range(0, _eventDatasSuitable.Count);

        GameObject createdEvent = Instantiate(_eventPrefabBasis, where);
        EventScript createdEventScript = createdEvent.GetComponent<EventScript>(); // get the EventScript of the new event GameObject

        // update the event contained in the new event GameObject, then load it to display it and update its script
        createdEventScript.currentEvent = _eventDatasSuitable[selectedEventIndexDATA];
        createdEventScript.LoadThis();
    }


    // Previous version, based on prefabs of events

    // Creates a list with every suitable events for this oufitude degre
    /*private void CreateSuitableEventList()
    {
        int degreDeOufitude = _statsManager.OufitudeDegre;

        foreach (GameObject eventPrefab in _eventPrefabs)
        {
            SO_Events eventData = eventPrefab.GetComponent<EventScript>().currentEvent;

            // check if the event belongs to the Oufitude degre range, add it to the list if so
            if (IsInOufitudeRange(eventPrefab, degreDeOufitude))
            {
                //print($"{eventPrefab.name} ({eventData.OufitudePool.Minimum}, {eventData.OufitudePool.Maximum}) is suitable for {degreDeOufitude}");
                _eventsSuitable.Add(eventPrefab);
            }
        }
    }

    // Checks if the event range fits with the Oufitude degre
    private bool IsInOufitudeRange(GameObject checkedEventPrefab, int degreToCompare)
    {
        SO_Events eventData = checkedEventPrefab.GetComponent<EventScript>().currentEvent;
        if (!(eventData.OufitudePool.Minimum > degreToCompare | eventData.OufitudePool.Maximum < degreToCompare))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InstantiateEvent(Transform where)
    {
        int selectedEventIndex = Random.Range(0, _eventsSuitable.Count);
        //print(_eventsSuitable[selectedEventIndex]);
        Instantiate(_eventsSuitable[selectedEventIndex], where);
    }*/
}
