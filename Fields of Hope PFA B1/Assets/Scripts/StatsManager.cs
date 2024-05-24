using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    // System stats
    //[Header("System stats")]
    //[Range(0, 100)]
    //[SerializeField]

    public int Life {

        get => _myStat[InventoryEnum.Life];
        set => _myStat[InventoryEnum.Life] = value;
    }

    private int _previousLife; // used to tween Hunger Bar at change

    [field: Range(0, 100)]
    [field: SerializeField]
    public int Hunger { get; set; }

    private int _previousHunger; // used to tween Hunger Bar at change

    [field: SerializeField]
    public int Seeds { get; set; }

    [field: SerializeField]
    public int Food { get; set; }

    [field: SerializeField] // TEMPORARY
    public int OufitudeDegre { get; set; } // number used to check

    // Vegetables inventory
    [Header("Vegetables")]
    public int Carotte; // inchallah faudra faire l'inventaire un jour hein
    public int Betterave;
    public int Poireau;
    public int Potiron;
    public int Patate;
    public int Rutabaga;
    public int Topinambour;
    public int Radis;

    [field: Header("UI")] // UI
    public TextMeshProUGUI LifeAmount;
    public TextMeshProUGUI HungerAmount;
    public TextMeshProUGUI SeedsAmount;
    public TextMeshProUGUI FoodAmount;

    public Image LifeBar;
    public Image HungerBar;

    private Dictionary<InventoryEnum, int> _myStat = new Dictionary<InventoryEnum, int>() {
        {InventoryEnum.Life, 0},
        {InventoryEnum.Hunger, 0},
        {InventoryEnum.Seeds, 0},
        {InventoryEnum.Day, 0}
    };

    public event Action OnDeath;

    public void ChangeValues(InventoryEnum value, int amount)
    {
        _myStat[value] = Mathf.Clamp(_myStat[value] + amount, 0, 100);
        if (IsDead()) { OnDeath?.Invoke(); }
        /*switch (value)
        {
            case InventoryEnum.Life:
                Life = Mathf.Clamp(Life + amount, 0, 100);
                
                break;

            case InventoryEnum.Hunger:
                Hunger = Mathf.Clamp(Hunger + amount, 0, 100);
                break;

            case InventoryEnum.Seeds:
                Seeds = Mathf.Clamp(Seeds + amount, 0, 100);
                break;

            case InventoryEnum.Day:
                // à faire
                break;
        }*/
        UpdateTexts();
        UpdateBars();
    }

    public void UpdateTexts()
    {
        LifeAmount.text = (Life).ToString();
        HungerAmount.text = (Hunger).ToString();
        SeedsAmount.text = (Seeds).ToString();
        FoodAmount.text = (Food).ToString();
    }

    public void UpdateBars()
    {
        LifeBar.DOFillAmount(Life / 100f, 0.1f + _previousLife / 100);
        HungerBar.DOFillAmount(Hunger / 100f, 0.1f + _previousHunger / 100);
    }

    /// <summary>
    /// Returns the amount of damage that will be taken from the hunger, scaling with starving stages.
    /// </summary>
    /// <returns></returns>
    public int GetHungerConsequence()
    {
        int healthChange = 0;
        switch (Hunger)
        {
            case 100:
                healthChange = 20;
                break;

            case < 100 and >= 90:
                healthChange = 10;
                break;

            case < 90 and >= 80:
                healthChange = 5;
                break;

            case <= 20 and > 10:
                healthChange = -5;
                break;

            case <= 10 and > 0:
                healthChange = -10;
                break;

            case 0:
                healthChange = -20;
                break;
        }
        return healthChange;
    }

    private bool IsDead()
    {
        return Life == 0 ? true : false;
    }

    private void Start()
    {
        // On initialise les variables avec des valeurs prédéfinies
        Life = 100;
        UpdateTexts();
        UpdateBars();
    }

    private void Update()
    {
        print(Life);
    }
}
