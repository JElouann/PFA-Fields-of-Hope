using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [field: Header("System stats")] // System stats
    [field: Range(0, 100)]
    [field: SerializeField]
    public int Life { get; private set; }

    [field: Range(0, 100)]
    [field: SerializeField]
    public int Hunger { get; private set; }

    [field: SerializeField]
    public int Seeds { get; private set; }

    [field: SerializeField]
    public int Food { get; private set; }

    [field: SerializeField] // TEMPORARY
    public int OufitudeDegre { get; set; } // number used to check

    // Vegetables inventory
    [Header("Vegetables")]
    public int Carotte; // inchallah faudra faire l'inventaire un jour hein
    public int Beterave;
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

    public void ChangeValues(string value, int amount)
    {
        switch (value)
        {
            case "Life":
                if (Life + amount > 0 && Life + amount <= 100) // Range attribute doesnt always work so we do it manually.
                {
                    Life += amount;
                }
                else if (amount > 0)
                {
                    Life = 100;
                }
                else
                {
                    Life = 0;
                }
                break;

            case "Hunger":
                if (Hunger + amount > 0 && Hunger + amount <= 100) // Range attribute
                {
                    Hunger += amount;
                }
                else if (amount > 0)
                {
                    Hunger = 100;
                }
                else
                {
                    Hunger = 0;
                }
                break;

            case "Seeds":
                if (Seeds + amount > 0) // Range attribute
                {
                    Seeds += amount;
                }
                else
                {
                    Seeds = 0;
                }
                break;

            case "Food":
                if (Food + amount > 0) // Range attribute
                {
                    Food += amount;
                }
                else
                {
                    Food = 0;
                }
                break;

            case "Day":
                // à faire
                break;
        }
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
        LifeBar.fillAmount = Life / 100f;
        HungerBar.fillAmount = Hunger / 100f;
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

    private void Update()
    {
        //UpdateTexts();
        //UpdateBars();
    }

    private void Start()
    {
        UpdateTexts();
        UpdateBars();
    }
}
