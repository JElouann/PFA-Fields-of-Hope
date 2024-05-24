using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField]
    private StatsManager _statsManager;
    [SerializeField]
    private GameObject _deadPlaceHolder;

    private void Awake()
    {
        _statsManager.OnDeath += Dead;
    }

    public async void Dead()
    {
        await Task.Delay(400);
        print("jui mor");
        _deadPlaceHolder.SetActive(true);
    }
}
