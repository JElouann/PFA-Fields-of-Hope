using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    [SerializeField]
    private DayManager _dayManager;

    public void OnEndDay()
    {
        print("�a marche");
    }
}