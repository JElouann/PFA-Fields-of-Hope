using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LogoGameFeel : MonoBehaviour
{
    public IEnumerator More()
    {
        this.transform.DOScale(new Vector3(1.45f, 1.35f, 1.45f), 0.425f).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.2f);
        this.transform.DOScale(Vector3.one, 0.3f);
    }

    public IEnumerator Hunger()
    {
        this.transform.DOScale(new Vector3(1.45f, 1.35f, 1.45f), 0.425f).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.2f);
        this.transform.DOScale(Vector3.one, 0.3f);
    }
}
