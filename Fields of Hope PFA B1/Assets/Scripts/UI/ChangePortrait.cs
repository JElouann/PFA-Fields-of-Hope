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

    private void Update() //
    {
        UpdatePortrait();
    }

    public void UpdatePortrait() // doit marcher avec event
    {
        switch(_statsManager.Life)
        {
            case  >= 0 and < 25:
                _portrait.sprite = _stateList[0];
                break;
            case >= 25 and < 50:
                _portrait.sprite = _stateList[1];
                break;
            case >= 50 and < 75:
                _portrait.sprite = _stateList[2];
                break;
            case >= 75 and <= 100:
                _portrait.sprite= _stateList[3];
                break;
        }
    }
}
