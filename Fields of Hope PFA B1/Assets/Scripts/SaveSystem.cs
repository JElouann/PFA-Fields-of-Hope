using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class SaveSystem : MonoBehaviour
{
    public static int saveSlot;


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

    private void Start()
    {
        LoadData();
    }



    public void SaveData()
    {
        PlayerPrefs.SetInt("Day", dayManager._dayCounter);
        PlayerPrefs.SetInt("Life", statsManager.Life);
        PlayerPrefs.SetInt("Hunger", statsManager.Hunger);
        PlayerPrefs.SetInt("Seeds", statsManager.Seeds);
        PlayerPrefs.SetInt("Food", statsManager.Food);

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
    }

    public void LoadData()
    {
        dayManager._dayCounter = PlayerPrefs.GetInt("Day");
        statsManager.Life = PlayerPrefs.GetInt("Life");
        statsManager.Hunger = PlayerPrefs.GetInt("Hunger");
        statsManager.Seeds = PlayerPrefs.GetInt("Seeds");
        statsManager.Food = PlayerPrefs.GetInt("Food");
        statsManager.UpdateTexts();
        statsManager.UpdateBars();
    }

    public void DeleteData()
    {
        dayManager._dayCounter = -1;
        dayManager.NextDay();
        statsManager.Life = 50;
        statsManager.Hunger = 45;
        statsManager.Seeds = 15;
        statsManager.Food = 5;
        statsManager.UpdateTexts();
        statsManager.UpdateBars();
        SaveData();
    }
}
