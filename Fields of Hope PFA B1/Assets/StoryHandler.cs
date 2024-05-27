using System.Collections.Generic;
using UnityEngine;

public class StoryHandler : MonoBehaviour
{
    private EventInstancier _eventInstancier;

    [field: Header("Day counters until next story event")]
    [field: SerializeField]
    public int First { get; set; }

    [field: SerializeField]
    public int Second { get; set; }

    [field: SerializeField]
    public int Third { get; set; }

    [field: SerializeField]
    public int Fourth { get; set; }

    [Header("Story events")]
    [SerializeField]
    private List<Histoire> _histoireEventDatas;

    private void Awake()
    {
        _eventInstancier = GetComponent<EventInstancier>();
    }

    public bool IsStoryEventToday()
    {
        bool toReturn = (First == 0 | Second == 0 | Third == 0 | Fourth == 0) ? true : false;
        return toReturn;
    }

    public SO_Events GetRandomStoryEvent()
    {
        int i = Random.Range(0, _histoireEventDatas.Count);
        return _histoireEventDatas[i].List[0];
    }
}
