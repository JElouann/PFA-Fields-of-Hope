using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoose : MonoBehaviour
{
    public SO_SeedsData PlantItem;

    public void Selected(SO_SeedsData item)
    {
        PlantItem = item;
        Debug.Log(PlantItem);
    }
}
