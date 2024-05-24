using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Seeds", menuName = "ScriptableObjects/Seeds", order = 3)]
public class SO_SeedsData : ScriptableObject
{
    public string Nom;
    
    public int TempsDePousseEnJours;

    public string Description;

    public int CoutEnGraines;

    public int Satiété;
}
