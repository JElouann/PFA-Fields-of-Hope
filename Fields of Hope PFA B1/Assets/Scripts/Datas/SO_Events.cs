using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ValueToChange
{
    public string Value;
    public int Amount;
}

[Serializable]
public class Interval
{
    public int Minimum;
    public int Maximum;
}

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class SO_Events : ScriptableObject
{
    [Header("Infos")]
    public string Name;
    [Multiline, Tooltip("The text or dialogue the event contains.")] public string Text;
    [Min(0), Tooltip("The ID the event will have in game datas.")] public int IDEvent;
    [Tooltip("The resume of this event the book will display.")] public string Description;

    [Header("Next events")]
    [Tooltip("The event the first option leads to (None if end).")] public SO_Events ChildEvent1;
    [Tooltip("The text the first button will display.")] public string Child1Text;
    [Tooltip("The event the second option leads to (None if end).")] public SO_Events ChildEvent2;
    [Tooltip("The text the second button will display.")] public string Child2Text;

    [Header("Style")]
    [Tooltip("The SO this event will use as graphic asset.")] public SO_EventAppearance Appearance;

    [Header("System Stats")]
    [Tooltip("The interval of oufitude degre in which the event can occure.")] public Interval OufitudePool;
    [Tooltip("List that contains pairs [value to change, amount of the changement].")] public List<ValueToChange> ValuesToChange;

    /// <summary>
    /// This method find recursively every path possible and return them as a string
    /// </summary>
    /// <param name="family"></param>
    /// <returns></returns>
    public string GetFamily(string family)
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

        // if there's only a "left" child
        if (ChildEvent1 != null && ChildEvent2 == null)
        {
            // return the result of this child's method
            return ChildEvent1.GetFamily(family) + " ";
        }
        // if there's only a "right" child
        else if (ChildEvent1 == null && ChildEvent2 != null)
        {
            // return the result of this child's method
            return ChildEvent2.GetFamily(family) + " ";
        }
        // if there are two children
        else if (ChildEvent1 != null && ChildEvent2 != null)
        {
            // return the result of these children's methods
            return ChildEvent1.GetFamily(family) + " " + ChildEvent2.GetFamily(family) + " ";
        }
        // if there's no child
        else
        {
            // return the actual result + indicates the end
            return family + "(End) |";
        }
    } 
}