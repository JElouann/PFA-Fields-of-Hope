using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomStruct
{
    public string ValueToChange;
    public int Amount;
}

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class SO_Events : ScriptableObject
{
    [Header("Infos")]
    public string Name;
    [Multiline] private string Description;
    [Min(0), Tooltip("The ID the event will have in game datas.")] private int IDEvent;

    [Header("Next events")]
    [Tooltip("The event the first option leads to (None if end).")] public SO_Events ChildEvent1;
    [Tooltip("The event the second option leads to (None if end).")] public SO_Events ChildEvent2;

    [Header("Style")]
    [Tooltip("The SO this event will use as graphic asset.")] public SO_EventAppearance Style;

    [Header("System Stats")]
    [Range(-10, 10), Tooltip("cf explications on OUFITUDE DEGRE tm")] public int DegreDeOufitude;
    [Tooltip("List that contains pairs [value to change, amount of the changement].")] public List<CustomStruct> ValuesToChange;

    public string GetFamily(string family) // retourne récursivement tous les cheminements possibles
    {
        //Debug.Log(family);
        switch (family)
        {
            case "":
                family += Name + " ";
                break;

            default:
                family += "--> " + Name + " ";
                break;
        }

        if (ChildEvent1 != null && ChildEvent2 == null)
        {
            return ChildEvent1.GetFamily(family) + " ";
        }
        else if (ChildEvent1 == null && ChildEvent2 != null)
        {
            return ChildEvent2.GetFamily(family) + " ";
        }
        else if (ChildEvent1 != null && ChildEvent2 != null)
        {
            return ChildEvent1.GetFamily(family) + " " + ChildEvent2.GetFamily(family) + " ";
        }
        else
        {
            return family + "(End) |";
        }
    } 
}
