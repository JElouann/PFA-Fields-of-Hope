using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstancier : MonoBehaviour
{
    [SerializeField]
    private GameObject _nextEvent;
    private GameObject _currentEvent;

    [SerializeField]
    private Transform _where;

    private void Start()
    {
        Instantiate(_nextEvent, _where);
    }
}
