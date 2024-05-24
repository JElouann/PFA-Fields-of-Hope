using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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

    #region GameFeel
    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (_selected) { return; }
        this.transform.SetAsLastSibling();
        this.transform.DOScale(_scaleOnHover, _scaleOnHoverSpeed);
        this.transform.DOLocalMove(_position + _slideDirection , 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if (_selected) { return; }
        this.transform.DOScale(Vector3.one, _unscaleSpeed);
        this.transform.DOLocalMove(_position, 0.3f);
    }
    #endregion

    private void Start()
    {
        _position = transform.localPosition;
    }
}
