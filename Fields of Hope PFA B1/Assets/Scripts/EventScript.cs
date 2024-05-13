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
    
    [field: SerializeField]
    public SO_Events currentEvent { get; set; }

    [SerializeField] private PageInstancier instancier;

    private List<ValueToChange> _valuesToChange;

    [SerializeField] private StatsManager StatsManager;

    /*private void Awake() // Only in prefab version
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
    }*/

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
        /*if (Random.Range(0, 2) == 0)
        {
            print(0);
            LeftButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = currentEvent.Child1Text;
            RightButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text= currentEvent.Child2Text;
        }
        else
        {
            print(1);
            LeftButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = currentEvent.Child2Text;
            RightButton.transform.Find("Text").GetComponent<TextMeshProUGUI>().text= currentEvent.Child1Text;
        }*/

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

    public void LoadThis()
    {
        // Find manager
        StatsManager = GameObject.FindObjectOfType<StatsManager>();

        // Find components
        _text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        LeftButton = transform.Find("LeftButton").GetComponent<Button>();
        RightButton = transform.Find("RightButton").GetComponent<Button>();

        // Initialize components
        UpdateEvent();
        LeftButton.onClick.AddListener(Left);
        RightButton.onClick.AddListener(Right);
    }
}
