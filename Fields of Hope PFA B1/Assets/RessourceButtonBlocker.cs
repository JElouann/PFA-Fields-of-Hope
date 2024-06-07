using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RessourceButtonBlocker : MonoBehaviour
{
    private StatsManager _statsManager;
    [SerializeField] private InventoryEnum _inventoryEnum;
    [SerializeField] private UnityEvent _checkToPerform;

    private void Awake()
    {
        _statsManager = FindAnyObjectByType<StatsManager>();
    }

    void Start()
    {
        GetComponent<Button>().interactable = (_statsManager._myStat[_inventoryEnum] > 0) ? true : false;
    }

    public bool CheckSeedsAmount()
    {
        return true;
    }

    public bool CheckVegetableAmount()
    {
        return true;
    }
}
