using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortrait : MonoBehaviour
{
    [SerializeField]
    private Image _portrait;
    private StatsManager _statsManager;
    [SerializeField]
    private List<Sprite> _stateList;

    private void Awake()
    {
        _statsManager = GameObject.FindAnyObjectByType<StatsManager>();
    }

    private void Update()
    {
        print(_statsManager.Life);
        _portrait.sprite = _stateList[(_statsManager.Life/100)*4];
        print((_statsManager.Life/100)*4);
    }
}
