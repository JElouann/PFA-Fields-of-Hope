using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponentInChildren<RessourceButtonBlocker>().CheckVegetableAmount())
        {
            print(this.transform.name);
            this.transform.DOScale(1.2f, 0.2f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GetComponentInChildren<RessourceButtonBlocker>().CheckVegetableAmount())
        {
            this.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        }
    }
}
