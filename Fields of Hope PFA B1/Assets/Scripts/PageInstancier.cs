using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageInstancier : MonoBehaviour
{
    public SO_Events CurrentEvent;
    public GameObject EventPrefab;
    public Button left;
    public Button right;

    public void InstantiateEvent()
    {
        Instantiate(EventPrefab, transform);   
    }

    // Start is called before the first frame update
    void Start()
    {
        //InstantiateEvent();
    }

    private void Awake()
    {
        //left.onClick.AddListener(InstantiateEvent);
    }
}
