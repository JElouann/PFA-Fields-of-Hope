using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    [SerializeField]
    private DayManager _dayManager;

    private void Start()
    {
        
    }

    public void OnEndDay()
    {
        print("ça marche");
    }
}
