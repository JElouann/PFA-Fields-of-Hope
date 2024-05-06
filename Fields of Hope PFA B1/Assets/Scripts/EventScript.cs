using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Button LeftButton;
    private Button RightButton;

    private SO_Events previousEvent;
    [SerializeField] private SO_Events currentEvent;

    [SerializeField] private PageInstancier instancier;

    private List<ValueToChange> _valuesToChange;

    [SerializeField] private StatsManager StatsManager;

    private void Awake()
    {
        // Find manager
        StatsManager = GameObject.FindObjectOfType<StatsManager>();

        // Find components
        _text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        LeftButton = transform.Find("LeftButton").GetComponent<Button>();
        RightButton = transform.Find("RightButton").GetComponent <Button>();

        // Initialize components
        UpdateEvent();
        LeftButton.onClick.AddListener(Left);
        RightButton.onClick.AddListener(Right);
    }

    public void Left()
    {
        print("left");
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent1;
        UpdateEvent();
    }

    public void Right() 
    {
        print("right");
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent2;
        UpdateEvent();
    }

    public void UpdateEvent()
    {
        _text.text = currentEvent.Text;
        LeftButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = currentEvent.Child1Text;
        RightButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text= currentEvent.Child2Text;
        foreach (ValueToChange ValueToChange in currentEvent.ValuesToChange)
        {
            StatsManager.ChangeValues(ValueToChange.Value, ValueToChange.Amount);
        }
        if(currentEvent.ChildEvent1 == null)
        {
            LeftButton.gameObject.SetActive(false);
        }
        if(currentEvent.ChildEvent2 == null)
        {
            RightButton.gameObject.SetActive(false);
        }
    }
}
