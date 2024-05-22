using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    public TMP_InputField inputField;

    [SerializeField]
    private StatsManager statsManager;

    [SerializeField]
    private DayManager dayManager;

    private int day;
    private int Life;
    private int Hunger;
    private int Seeds;

    private int carotte;
    private int betterave;
    private int poireau;
    private int potiron;
    private int pommedeterre;
    private int rutabaga;
    private int topinambour;
    private int radis;

    private void Awake()
    {

    }
    public void SaveData()
    {
        PlayerPrefs.SetString("Input", inputField.text);
        Debug.Log("SAVE");
    }

    public void LoadData()
    {
        inputField.text = PlayerPrefs.GetString("Input");
        Debug.Log("LOAD");
    }

    public void DeleteData()
    {
        inputField.text = string.Empty;
    }
}
