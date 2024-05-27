using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonGameFeel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _position;

    [Header("Gamefeel")]
    [SerializeField] private Vector3 _scaleOnHover;
    [SerializeField] private float _scaleOnHoverSpeed;
    [SerializeField] private float _unscaleSpeed;

    [Space(5)]

    [SerializeField] private Vector3 _slideDirection;
    [SerializeField] private float _slideValue;
    [SerializeField] private Type _type;

    public static bool _canBeSelected { get; set; }

    #region GameFeel
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DayChoice._selected) { return; }
        this.transform.SetAsLastSibling();
        this.transform.DOScale(_scaleOnHover, _scaleOnHoverSpeed);
        this.transform.DOLocalMove(_position + _slideDirection , 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DayChoice._selected) { return; }
        this.transform.DOScale(Vector3.one, _unscaleSpeed);
        this.transform.DOLocalMove(_position, 0.3f);
    }

    public void SelectedGameFeel(int direction)
    {
        this.transform.DOLocalMoveX(transform.localPosition.x + (80 * direction), 0.8f);
        this.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.8f);
    }

    public async void NotSelectedGameFeel()
    {
        this.GetComponent<Image>().DOFade(0, 0.4f);
        this.transform.GetChild(0).GetComponent<Image>().DOFade(0, 0.4f);
        await Task.Delay(400);
        this.gameObject.SetActive(false);
    }

    public void ResetAppearance()
    {

    }
    #endregion

    private void Start()
    {
        _position = transform.localPosition;
    }
}