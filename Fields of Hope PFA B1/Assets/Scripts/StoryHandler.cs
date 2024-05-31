using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StoryHandler : MonoBehaviour
{
    private EventInstancier _eventInstancier;

    [field: Header("Day counters until next story event")]
    [field: SerializeField]
    public List<int> StoryChronos { get; set; }

    [field: Header("Story events")]
    [field: SerializeField]
    public List<SO_Events> FirstPoolEvents { get; set; }
    [field: SerializeField]
    public List<SO_Events> SecondPoolEvents { get; set; }
    [field: SerializeField]
    public List<SO_Events> ThirdPoolEvents { get; set; }
    [field: SerializeField]
    public List<SO_Events> FourthPoolEvents { get; set; }

    private List<List<SO_Events>> _poolEvents = new();
    private int _selectedPool;

    private int _storyIndex; // represents the current state in the stroy pool

    private bool _isSelectedPool; // prevents EventInstancier to reset this handler

    private void Awake()
    {
        _eventInstancier = GetComponent<EventInstancier>();
        _poolEvents.Add(FirstPoolEvents);
        _poolEvents.Add(SecondPoolEvents);
        _poolEvents.Add(ThirdPoolEvents);
        _poolEvents.Add(FourthPoolEvents);
    }

    public bool IsStoryEventToday()
    {
        bool toReturn = (StoryChronos[_storyIndex] == 0) ? true : false;
        return toReturn;
    }

    public SO_Events GetRandomStoryEvent()
    {
        if (!_isSelectedPool)
        {
            int i = Random.Range(0, 3);
            return _poolEvents[i][0];
        }
        return _poolEvents[_selectedPool][_storyIndex];
    }

    // trouver le moyen de lock le pool quand la condition de l'event est rempli
}
