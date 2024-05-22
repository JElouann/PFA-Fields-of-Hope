using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SaveSystem : MonoBehaviour
{
    //public TMP_InputField inputField;

    [SerializeField]
    private StatsManager statsManager;

    [SerializeField]
    private DayManager dayManager;

    private int day;
    private int Life;
    private int Hunger;
    private int Seeds;
    private int food;

    /*
    private int carotte;
    private int betterave;
    private int poireau;
    private int potiron;
    private int pommedeterre;
    private int rutabaga;
    private int topinambour;
    private int radis;
    */

    public TextMeshProUGUI dayTMP;
    public TextMeshProUGUI LifeTMP;
    public TextMeshProUGUI HungerTMP;
    public TextMeshProUGUI SeedsTMP;
    public TextMeshProUGUI foodTMP;

    /*
    private int carotteTMP;
    private int betteraveTMP;
    private int poireauTMP;
    private int potironTMP;
    private int pommedeterreTMP;
    private int rutabagaTMP;
    private int topinambourTMP;
    private int radisTMP;
    */

    public void SaveData()
    {
        //PlayerPrefs.SetString("Input", inputField.text);
        day = dayManager._dayCounter;
        Life = statsManager.Life;
        Hunger = statsManager.Hunger;
        Seeds = statsManager.Seeds;
        food = statsManager.Food;


        /*
        carotte = statsManager.Carotte;
        betterave = statsManager.Beterave;
        poireau = statsManager.Poireau;
        potiron = statsManager.Potiron;
        pommedeterre = statsManager.Patate;
        rutabaga = statsManager.Rutabaga;
        topinambour = statsManager.Topinambour;
        radis = statsManager.Radis;
        */
        Debug.Log("SAVE");
    }

    public void LoadData()
    {
        //inputField.text = PlayerPrefs.GetString("Input");
        dayTMP.text = day.ToString();
        LifeTMP.text = Life.ToString();
        HungerTMP.text = Hunger.ToString();
        SeedsTMP.text = Seeds.ToString();
        foodTMP.text = food.ToString();
        /*dayManager._dayCounter = day;
        statsManager.Life = Life;
        statsManager.Hunger = Hunger;
        statsManager.Seeds = Seeds;
        statsManager.Food = food;*/
        Debug.Log("LOAD");
    }

    public void DeleteData()
    {
        //inputField.text = string.Empty;
        dayTMP = null;
        LifeTMP = null;
        HungerTMP = null;
        SeedsTMP = null;
        foodTMP = null;
    }
}
