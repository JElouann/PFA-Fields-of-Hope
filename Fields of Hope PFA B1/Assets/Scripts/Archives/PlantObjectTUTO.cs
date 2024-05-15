using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PLANTTUTO", menuName = "ScriptableObjects/SeedsTuto", order = 4)]
public class PlantObjectTUTO : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwStages;
    public Sprite icon;
}