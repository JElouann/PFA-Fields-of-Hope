using System;
using System.Collections.Generic;
using TMPro;
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

    public GameObject GizmosSprite;
    public GameObject Image;

    public event Action OnEndEvent;

    public void Left() // left button
    {
        if (!CheckConditions(currentEvent.Child1Conditions)) return;
        previousEvent = currentEvent;
        currentEvent = currentEvent.ChildEvent1;
        UpdateEvent();
    }

    public void Right() // right button
    {
        if (!CheckConditions(currentEvent.Child2Conditions)) return;
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
            case GameVariables.Life:
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

        DialogueBox dialogueBox = transform.Find("TextBox").GetComponent<DialogueBox>(); // ICI LA 
        dialogueBox._text = transform.Find("TextBox").transform.Find("Text").GetComponent<TextMeshProUGUI>(); //
        dialogueBox.StartDialogue(currentEvent.Text); //

        leftText.text = currentEvent.Child1Text;
        rightText.text = currentEvent.Child2Text;
        
        foreach (ValueToChange ValueToChange in currentEvent.ValuesToChange)
        {
            StatsManager.ChangeValues(ValueToChange.Value, ValueToChange.Amount, true);
        }

        LeftButton.gameObject.SetActive(false);

        RightButton.gameObject.SetActive(false);

        for (int i = 0; i < currentEvent.StyleEvent.Count; i++)
        {
            GameObject spriteCreated = Instantiate(Image, currentEvent.StyleEvent[i].SpritePosition, currentEvent.StyleEvent[i].SpriteRotation, GizmosSprite.transform);
            RectTransform rectTransform = spriteCreated.GetComponent<RectTransform>();
            rectTransform.sizeDelta = currentEvent.StyleEvent[i].SpriteLongueurAndLargeur;
            spriteCreated.transform.localScale = currentEvent.StyleEvent[i].SpriteScale;
            Image PipolopoSprite = spriteCreated.GetComponent<Image>();
            PipolopoSprite.sprite = currentEvent.StyleEvent[i].ImageEvent;
        }
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
        if (currentEvent.ChildEvent1 == null && currentEvent.ChildEvent2 == null)
        {
            OnEndEvent.Invoke();
        }
        else
        {
            if (currentEvent.ChildEvent1 != null)
            {
                LeftButton.gameObject.SetActive(true);
            }
            if (currentEvent.ChildEvent2 != null)
            {
                RightButton.gameObject.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        dialogueBox = transform.Find("TextBox").GetComponent<DialogueBox>(); //
        this.dialogueBox.OnEndTextDisplay += this.OnEndDisplayDialogue;
    }
}
