using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstancier : MonoBehaviour
{
    // pour proto ou test
    [SerializeField]
    private GameObject _nextEvent;
    private GameObject _currentEvent;

    // Composant requis
    private StatsManager _statsManager;

    [SerializeField]
    private Transform _where;

    [SerializeField]
    private List<GameObject> _eventPrefabs;

    [SerializeField]
    private List<SO_Events> _eventDATAS; //

    private List<GameObject> _eventsSuitable = new();

    private List<SO_Events> _eventsSuitableDATAS = new();

    [SerializeField]
    private GameObject _eventPrefabEmptyTEST;

    private void Start()
    {
        //CreateSuitableEventList();
        //InstantiateEvent(_where);

        CreateSuitableEventListDATAVERSION();
        InstantiateEventDATA(_where);
    }

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
    }

    // Creates a list with every suitable events for this oufitude degre
    private void CreateSuitableEventList()
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

    private void CreateSuitableEventListDATAVERSION() //
    {
        int degreDeOufitude = _statsManager.OufitudeDegre;

        foreach (SO_Events eventData in _eventDATAS)
        {
            if (IsInOufitudeRangeDATAVERSION(eventData, degreDeOufitude))
            {
                _eventsSuitableDATAS.Add(eventData);
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

    private bool IsInOufitudeRangeDATAVERSION(SO_Events checkedEvent, int degreToCompare) //
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

    private void InstantiateEvent(Transform where)
    {
        int selectedEventIndex = Random.Range(0, _eventsSuitable.Count);
        //print(_eventsSuitable[selectedEventIndex]);
        Instantiate(_eventsSuitable[selectedEventIndex], where);
    }

    private void InstantiateEventDATA(Transform where) //
    {
        int selectedEventIndexDATA = Random.Range(0, _eventsSuitableDATAS.Count);
        /*foreach(SO_Events gngn in _eventsSuitableDATAS)
        {
            print(gngn);
        }*/

        GameObject createdEvent = Instantiate(_eventPrefabEmptyTEST, where);
        EventScript createdEventScript = createdEvent.GetComponent<EventScript>(); // get the EventScript of the new event GameObject

        // update the event contained in the new event GameObject, then load it to display it and update its script
        createdEventScript.currentEvent = _eventsSuitableDATAS[selectedEventIndexDATA];
        createdEventScript.LoadThis();
    }
}
