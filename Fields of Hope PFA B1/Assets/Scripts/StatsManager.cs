using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // In game stats
    [field: Range(0, 100)]
    public int Life { get; set; }
    
    // System stats
    public int DegréDeOufitude { get; set; }

    // UI
    public TextMeshProUGUI LifeAmount;


    public void ChangeLife(int value)
    {
        Debug.Log(int.Parse(LifeAmount.text));

        int currentLife = int.Parse(LifeAmount.text);
        LifeAmount.text = (currentLife + value).ToString();

        //LifeAmount.text = "GNGN";
        //Debug.Log(LifeAmount.text);
    }

    private void Start()
    {
        int gngn = int.Parse("45");
        //Debug.Log(gngn);
    }
}
