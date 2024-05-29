using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class StatsManager : MonoBehaviour
{
    // System stats
    //[Header("System stats")]
    //[Range(0, 100)]
    //[SerializeField]
    [SerializeField]
    private EndDayStats enddaystats;

    public int Life {

        get => _myStat[InventoryEnum.Life];
        set => _myStat[InventoryEnum.Life] = value;
    }

    private int _previousLife; // used to tween Hunger Bar at change

    public int Hunger {

        get => _myStat[InventoryEnum.Hunger];
        set => _myStat[InventoryEnum.Hunger] = value;
    }

    private int _previousHunger; // used to tween Hunger Bar at change

    public int Seeds {

        get => _myStat[InventoryEnum.Seeds];
        set => _myStat[InventoryEnum.Seeds] = value;
    }

    [field: SerializeField]
    public int Food { get; set; }

    public int OufitudeDegre
    {
        get => _myStat[InventoryEnum.DegreDeOufitude]; 
        set => _myStat[InventoryEnum.DegreDeOufitude] = value;
    }

    // Vegetables inventory
    public int Carotte
    {
        get => _myStat[InventoryEnum.Carotte];
        set => _myStat[InventoryEnum.Carotte] = value;
    }

    public int Betterave
    {
        get => _myStat[InventoryEnum.Betterave];
        set => _myStat[InventoryEnum.Betterave] = value;
    }
    public int Poireau
    {
        get => _myStat[InventoryEnum.Poireau];
        set => _myStat[InventoryEnum.Poireau] = value;
    }
    public int Potiron
    {
        get => _myStat[InventoryEnum.Potiron];
        set => _myStat[InventoryEnum.Potiron] = value;
    }

    public int Patate
    {
        get => _myStat[InventoryEnum.Patate];
        set => _myStat[InventoryEnum.Patate] = value;
    }
    public int Rutabaga
    {
        get => _myStat[InventoryEnum.Rutabaga];
        set => _myStat[InventoryEnum.Rutabaga] = value;
    }
    public int Topinambour
    {
        get => _myStat[InventoryEnum.Topinambour];
        set => _myStat[InventoryEnum.Topinambour] = value;
    }
    public int Radis
    {
        get => _myStat[InventoryEnum.Radis];
        set => _myStat[InventoryEnum.Radis] = value;
    }

    public int Medkit
    {
        get => _myStat[InventoryEnum.Medkit];
        set => _myStat[InventoryEnum.Medkit] = value;
    }

    [field: Header("UI")] // UI
    public TextMeshProUGUI LifeAmount;
    public TextMeshProUGUI HungerAmount;
    public TextMeshProUGUI SeedsAmount;
    public TextMeshProUGUI FoodAmount;

    public Image LifeBar;
    public Image HungerBar;

    public Dictionary<InventoryEnum, int> _myStat = new Dictionary<InventoryEnum, int>() {
        {InventoryEnum.Life, 0},
        {InventoryEnum.Hunger, 0},
        {InventoryEnum.Seeds, 0},
        {InventoryEnum.Carotte, 0},
        {InventoryEnum.Betterave, 0},
        {InventoryEnum.Poireau, 0},
        {InventoryEnum.Potiron, 0},
        {InventoryEnum.Patate, 0},
        {InventoryEnum.Rutabaga, 0},
        {InventoryEnum.Topinambour, 0},
        {InventoryEnum.Radis, 0},
        {InventoryEnum.Day, 0},
        {InventoryEnum.Medkit, 0},
        {InventoryEnum.DegreDeOufitude, 0}
    };

    public event Action OnDeath;

    public void ChangeValues(InventoryEnum value, int amount)
    {
        _myStat[value] = (value == InventoryEnum.DegreDeOufitude) ? Mathf.Clamp(_myStat[value] + amount, 0, 10) : Mathf.Clamp(_myStat[value] + amount, 0, 100);
        if (IsDead()) { OnDeath?.Invoke(); }

        //print(OufitudeDegre); //
        UpdateTexts();
        UpdateBars();
        enddaystats.OnStatsChange(value, amount);
    }

    public bool CheckRessource(InventoryEnum value)
    {
        print(value);
        return (_myStat[value] > 0);
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

    private void Awake()
    {
        // On initialise les variables avec des valeurs prédéfinies
        Life = 60;
        Hunger = 50;
        Seeds = 30;
        Patate = 2;

        UpdateTexts();
        UpdateBars();
    }
}
