using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private GameObject _inventoryPanel;

    [SerializeField] private TextMeshProUGUI _carotteAmount;
    [SerializeField] private TextMeshProUGUI _betteraveAmount;
    [SerializeField] private TextMeshProUGUI _poireauAmount;
    [SerializeField] private TextMeshProUGUI _potironAmount;
    [SerializeField] private TextMeshProUGUI _patateAmount;
    [SerializeField] private TextMeshProUGUI _rutabagaAmount;
    [SerializeField] private TextMeshProUGUI _radisAmount;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _inventoryPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _inventoryPanel.SetActive(false);
    }

    public void UpdateAmounts()
    {

    }
}
