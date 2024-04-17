using TMPro;
using UnityEngine;

public class ManagementDay : MonoBehaviour
{
    public TextMeshProUGUI Day;
    private int NB_Day = 1;
    private PlotManager[] plotManagers;

    private void Start()
    {
        plotManagers = FindObjectsOfType<PlotManager>();
    }

    void Update()
    {
        Day.text = "Jour : " + NB_Day;
    }

    public void NextDay()
    {
        NB_Day++;
        foreach (PlotManager plotmanager in plotManagers)
        {
            plotmanager.GrowthPlant();
        }
    }
}
