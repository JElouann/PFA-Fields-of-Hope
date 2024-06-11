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
        PlayerPrefs.SetInt("Carotte", statsManager.Carotte);
        PlayerPrefs.SetInt("Betterave", statsManager.Betterave);
        PlayerPrefs.SetInt("Patate", statsManager.Patate);
        PlayerPrefs.SetInt("Potiron", statsManager.Potiron);
        PlayerPrefs.SetInt("Rutabaga", statsManager.Rutabaga);
        PlayerPrefs.SetInt("Topinambour", statsManager.Topinambour);
        PlayerPrefs.SetInt("Radis", statsManager.Radis);
        PlayerPrefs.SetInt("Poireau", statsManager.Poireau);
    }

    public void LoadData()
    {
        dayManager._dayCounter = PlayerPrefs.GetInt("Day");
        statsManager.Life = PlayerPrefs.GetInt("Life");
        statsManager.Hunger = PlayerPrefs.GetInt("Hunger");
        statsManager.Seeds = PlayerPrefs.GetInt("Seeds");
        statsManager.Carotte = PlayerPrefs.GetInt("Carotte");
        statsManager.Betterave = PlayerPrefs.GetInt("Betterave");
        statsManager.Patate = PlayerPrefs.GetInt("Patate");
        statsManager.Potiron = PlayerPrefs.GetInt("Potiron");
        statsManager.Rutabaga = PlayerPrefs.GetInt("Rutabaga");
        statsManager.Topinambour = PlayerPrefs.GetInt("Topinambour");
        statsManager.Radis = PlayerPrefs.GetInt("Radis");
        statsManager.Poireau = PlayerPrefs.GetInt("Poireau");
        dayManager.UpdateTextDay();
        statsManager.UpdateTexts();
        statsManager.UpdateBars();
    }

    public void NewGame()
    {
        dayManager._dayCounter = 0;
        statsManager.Life = 50;
        statsManager.Hunger = 45;
        statsManager.Seeds = 15;
        statsManager.Carotte = 2;
        statsManager.OufitudeDegre = 5;
        dayManager.UpdateTextDay();
        statsManager.UpdateTexts();
        statsManager.UpdateBars();
        SaveData();
    }
}