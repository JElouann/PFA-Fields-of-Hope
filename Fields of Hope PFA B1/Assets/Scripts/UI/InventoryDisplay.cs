using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private GameObject _inventoryPanel;

    [SerializeField] private TextMeshProUGUI _radisAmount;
    [SerializeField] private TextMeshProUGUI _poireauAmount;
    [SerializeField] private TextMeshProUGUI _topinambourAmount;
    [SerializeField] private TextMeshProUGUI _rutabagaAmount;
    [SerializeField] private TextMeshProUGUI _carotteAmount;
    [SerializeField] private TextMeshProUGUI _betteraveAmount;
    [SerializeField] private TextMeshProUGUI _patateAmount;
    [SerializeField] private TextMeshProUGUI _potironAmount;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _inventoryPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _inventoryPanel.SetActive(false);
    }

    public void UpdateAmounts(InventoryEnum type)
    {
        switch(type)
        {
            case InventoryEnum.Radis:
                _radisAmount.text = _statsManager.Radis.ToString();
                break;
            case InventoryEnum.Poireau:
                _poireauAmount.text = _statsManager.Poireau.ToString();
                break;
            case InventoryEnum.Topinambour:
                _topinambourAmount.text = _statsManager.Topinambour.ToString();
                break;
            case InventoryEnum.Rutabaga:
                _rutabagaAmount.text = _statsManager.Rutabaga.ToString();
                break;
            case InventoryEnum.Carotte:
                _carotteAmount.text = _statsManager.Carotte.ToString();
                break;
            case InventoryEnum.Betterave:
                _betteraveAmount.text = _statsManager.Betterave.ToString();
                break;
            case InventoryEnum.PommeDeTerre:
                _patateAmount.text = _statsManager.Patate.ToString();
                break;
            case InventoryEnum.Potiron:
                _potironAmount.text = _statsManager.Potiron.ToString();
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        _radisAmount.text = _statsManager.Radis.ToString();
        _poireauAmount.text = _statsManager.Poireau.ToString();
        _topinambourAmount.text = _statsManager.Topinambour.ToString();
        _rutabagaAmount.text = _statsManager.Rutabaga.ToString();
        _carotteAmount.text = _statsManager.Carotte.ToString();
        _betteraveAmount.text = _statsManager.Betterave.ToString();
        _patateAmount.text = _statsManager.Patate.ToString();
        _potironAmount.text = _statsManager.Potiron.ToString();
    }
}
