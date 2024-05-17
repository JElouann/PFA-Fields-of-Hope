using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        if (!CheckConditions(currentEvent.Child1Conditions)) return;

        print("left");
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent1;
        UpdateEvent();
    }

    public void Right() 
    {
        if (!CheckConditions(currentEvent.Child2Conditions)) return;

        print("right");
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent2;
        UpdateEvent();
    }

    private bool CheckConditions(List<Condition> conditions) //
    {
        foreach (Condition condition in conditions)
        {
            if (!CheckCondition(condition)) return false;
        }
        return true;
    }

    private bool CheckCondition(Condition condition) //
    {
        // Récupération de la valeur
        int value;
        switch (condition.Variable)
        {
            case GameVariables.Health:
                value = StatsManager.Life;
                return TEEEEST(condition, value);
                //break;
            case GameVariables.Seeds:
                value = StatsManager.Seeds;
                return TEEEEST(condition, value);
                //break;
            default: return false;
        }

        /*// Comparer avec l'opérateur
        switch (condition.Operator)
        {
            case Operator.Equal:
                return value == condition.Amount;
            case Operator.Less:
                return value < condition.Amount;
        }*/
    }

    public bool TEEEEST(Condition condition, int value) //
    {
        // Comparer avec l'opérateur
        switch (condition.Operator)
        {
            case Operator.Equal:
                return value == condition.Amount;
            case Operator.Less:
                return value < condition.Amount;
            case Operator.LessOrEqual: 
                return value <= condition.Amount;
            case Operator.More: 
                return value > condition.Amount;
            case Operator.MoreOrEqual: 
                return value >= condition.Amount;
            case Operator.Different: 
                return value != condition.Amount;
            default: 
                return false;
        }
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

        TextMeshProUGUI leftText = LeftButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI rightText = RightButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        
        leftText.text = currentEvent.Child1Text;
        rightText.text = currentEvent.Child2Text;
        
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
