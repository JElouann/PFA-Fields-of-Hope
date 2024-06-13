using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public static int saveSlot;


    [SerializeField]
    private StatsManager statsManager;

    [SerializeField]
    private DayManager dayManager;

    [SerializeField]
    private Slider SliderMaster;

    [SerializeField]
    private Slider SliderSFX;

    [SerializeField]
    private Slider SliderMusic;

    [SerializeField]
    private Slider SliderAmbiance;

    private void Start()
    {
        LoadData();
        SetOption();
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
        PlayerPrefs.SetInt("OufitudeDegre", statsManager.OufitudeDegre);
        SaveOption();
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
        statsManager.OufitudeDegre = PlayerPrefs.GetInt("OufitudeDegre");
        dayManager.UpdateTextDay();
        statsManager.UpdateTexts();
        statsManager.UpdateBars();
        SetOption();
    }

    public void NewGame()
    {
        dayManager._dayCounter = 0;
        statsManager.Life = 50;
        statsManager.Hunger = 45;
        statsManager.Seeds = 15;
        statsManager.Radis = 5;
        statsManager.Carotte = 2;
        statsManager.OufitudeDegre = 1;
        dayManager.UpdateTextDay();
        statsManager.UpdateTexts();
        statsManager.UpdateBars();
        SaveData();
    }

    public void SaveOption()
    {
        PlayerPrefs.SetFloat("MasterVolume", SliderMaster.value);
        PlayerPrefs.SetFloat("SFXVolume", SliderSFX.value);
        PlayerPrefs.SetFloat("MusicVolume", SliderMusic.value);
        PlayerPrefs.SetFloat("AmbianceVolume", SliderAmbiance.value);
    }

    public void SetOption()
    {
        SliderMaster.value = PlayerPrefs.GetFloat("MasterVolume");
        SliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");
        SliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");
        SliderAmbiance.value = PlayerPrefs.GetFloat("AmbianceVolume");
    }
}