using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum TypeOfRessource
{
    Vegetable,
    Seeds
}

public class RessourceButtonBlocker : MonoBehaviour
{
    private StatsManager _statsManager;
    [SerializeField] private InventoryEnum _inventoryEnum;
    [SerializeField] private TypeOfRessource _typeOfRessource;
    [SerializeField] private SO_SeedsData _vegetablesData;
    [SerializeField] private UnityEvent _checkToPerform;

    private void Awake()
    {
        _statsManager = FindAnyObjectByType<StatsManager>();
    }

    private void Start()
    {
        if (_typeOfRessource == TypeOfRessource.Vegetable)
        {
            GetComponent<Button>().interactable = (_statsManager._myStat[_inventoryEnum] > 0);
            print(this.gameObject.transform.parent.name + " | LEGUME PROCK " + (_statsManager._myStat[_inventoryEnum] > 0));
        }
        else if(_typeOfRessource == TypeOfRessource.Seeds)
        {
            GetComponent<Button>().interactable = (_statsManager._myStat[InventoryEnum.Graines] >= _vegetablesData.CoutEnGraines);
            print(this.name + " | GRAINE PROCK " + (_statsManager._myStat[InventoryEnum.Graines] >= _vegetablesData.CoutEnGraines));
        }
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
