using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BookMarkBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _position;

    private void Awake()
    {
        _position = transform.localPosition;    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.GetComponent<Button>().interactable) 
        {
            this.transform.DOLocalMoveY(_position.y - 50f, 0.25f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.transform.position != _position)
        {
            this.transform.DOLocalMoveY(_position.y, 0.25f);
        }
    }
}
