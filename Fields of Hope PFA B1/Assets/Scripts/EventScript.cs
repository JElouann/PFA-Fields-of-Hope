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

    private List<ValueToChange> _valuesToChange;

    [SerializeField] private StatsManager StatsManager;

    private DialogueBox dialogueBox;

    public void Left() // left button
    {
        if (!CheckConditions(currentEvent.Child1Conditions)) return; // unable the use of this choice button if conditions unfullfilled (add game feel)

        print("left");
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent1;
        UpdateEvent();
    }

    public void Right() // right button
    {
        if (!CheckConditions(currentEvent.Child2Conditions)) return; // unable the use of this choice button if conditions unfullfilled (add game feel)

        print("right");
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent2;
        UpdateEvent();
    }

    #region Conditions methods
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
                return CompareWithOperator(condition, value);
                //break;
            case GameVariables.Seeds:
                value = StatsManager.Seeds;
                return CompareWithOperator(condition, value);
                //break;
            default: return false;
        }
    }

    public bool CompareWithOperator(Condition condition, int value) //
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
    #endregion

    public void UpdateEvent()
    {
        //_text.text = currentEvent.Text;
        
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
        DialogueBox dialogueBox = transform.Find("TextBox").GetComponent<DialogueBox>(); //
        dialogueBox._text = transform.Find("TextBox").transform.Find("Text").GetComponent<TextMeshProUGUI>(); //
        dialogueBox.StartDialogue(currentEvent.Text); //
        leftText.text = currentEvent.Child1Text;
        rightText.text = currentEvent.Child2Text;
        
        foreach (ValueToChange ValueToChange in currentEvent.ValuesToChange)
        {
            StatsManager.ChangeValues(ValueToChange.Value, ValueToChange.Amount);
        }

        LeftButton.gameObject.SetActive(false);

        RightButton.gameObject.SetActive(false);
    }

    public void LoadThis()
    {
        // Find manager
        StatsManager = GameObject.FindObjectOfType<StatsManager>();


        // Find components
        dialogueBox._text = transform.Find("TextBox").transform.Find("Text").GetComponent<TextMeshProUGUI>(); //
        //dialogueBox.StartDialogue(currentEvent.Text); //
        LeftButton = transform.Find("LeftButton").GetComponent<Button>();
        RightButton = transform.Find("RightButton").GetComponent<Button>();

        // Initialize components
        UpdateEvent();
        LeftButton.onClick.AddListener(Left);
        RightButton.onClick.AddListener(Right);
    }

    public void OnEndDisplayDialogue()
    {
        if (currentEvent.ChildEvent1 != null)
        {
            LeftButton.gameObject.SetActive(true);
        }
        if (currentEvent.ChildEvent2 != null)
        {
            RightButton.gameObject.SetActive(true);
        }
        // if tatata
        // show buttons
        print("event ok");
    }

    private void Awake()
    {
        dialogueBox = transform.Find("TextBox").GetComponent<DialogueBox>(); //
        this.dialogueBox.OnEndTextDisplay += this.OnEndDisplayDialogue;
    }
}
