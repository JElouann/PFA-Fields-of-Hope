using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class SO_Events : ScriptableObject
{
    [Header("Infos")]
    [Space(2)]
    public string Name;
    [Multiline, Tooltip("The text or dialogue the event contains.")] public string Text;

    [Header("Child 1")]
    [Space(2)]
    [Tooltip("The event the first option leads to (None if end).")] public SO_Events ChildEvent1;
    [Tooltip("The text the first button will display.")] public string Child1Text;
    public List<Condition> Child1Conditions;

    [Header("Child 2")]
    [Space(2)]
    [Tooltip("The event the second option leads to (None if end).")] public SO_Events ChildEvent2;
    [Tooltip("The text the second button will display.")] public string Child2Text;
    public List<Condition> Child2Conditions;

    [Header("Style")]
    [Space(2)]
    public Sprite ImageEvent;
    public Vector3 SpritePosition;
    public Quaternion SpriteRotation;
    public Vector3 SpriteScale;

    [Header("System Stats")]
    [Space(2)]
    [Tooltip("The interval of oufitude degre in which the event can occure.")] public Interval OufitudePool;
    [Space(10)]
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
