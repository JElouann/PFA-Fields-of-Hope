using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RessourceButtonBlocker : MonoBehaviour
{
    private StatsManager _statsManager;
    [SerializeField] private InventoryEnum _inventoryEnum;
    [SerializeField] private SO_SeedsData _vegetablesData;
    [SerializeField] private UnityEvent _checkToPerform;

    private void Awake()
    {
        _statsManager = FindAnyObjectByType<StatsManager>();
        CheckWhatHasToBeCheck();
    }

    public void CheckWhatHasToBeCheck()
    {
        _checkToPerform.Invoke();
    }

    public void BlockSeeds()
    {
        GetComponent<Button>().interactable = CheckSeedsAmount();
    }

    public bool CheckSeedsAmount()
    {
        bool isEnough = (_statsManager._myStat[InventoryEnum.Graines] >= _vegetablesData.CoutEnGraines) ? true : false;
        return isEnough;
    }

    public void BlockVegetables()
    {
        GetComponent<Button>().interactable = CheckVegetableAmount();
    }

    public bool CheckVegetableAmount()
    {
        bool isEnough = (_statsManager._myStat[_inventoryEnum] > 0) ? true : false;
        return isEnough;
    }
}
