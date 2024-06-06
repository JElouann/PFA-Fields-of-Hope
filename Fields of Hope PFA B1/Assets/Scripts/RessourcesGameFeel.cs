using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesGameFeel : MonoBehaviour
{
    [SerializeField] private Color _additionColor;
    [SerializeField] private Color _substractionColor;

    private GameObject _lifeLogo;
    private GameObject _hungerLogo;

    private TextMeshProUGUI _lifeText;
    private Vector3 _lifeTextPosition;

    private TextMeshProUGUI _hungerText;
    private Vector3 _hungerTextPosition;

    public IEnumerator LifeGainLogo()
    {
        _lifeLogo.transform.DOScale(new Vector3(1.45f, 1.35f, 1.45f), 0.425f).SetEase(Ease.OutElastic);
        yield return new WaitForSeconds(0.2f);
        _lifeLogo.transform.DOScale(Vector3.one, 0.3f);
    }

    public IEnumerator LifeLossLogo()
    {
        _lifeLogo.transform.DOPunchScale(new Vector3(0.75f, 0.75f, 0.75f), 3, 7, 0).SetEase(Ease.InOutBounce);
        yield return null;
    }

    public IEnumerator HungerGainLogo()
    {
        _hungerLogo.transform.DOScale(new Vector3(1.45f, 1.35f, 1.45f), 0.425f).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.2f);
        _hungerLogo.transform.DOScale(Vector3.one, 0.3f);
    }

    public IEnumerator HungerLossLogo()
    {
        _hungerLogo.transform.DOPunchScale(new Vector3(0.75f, 0.75f, 0.75f), 3, 7, 0).SetEase(Ease.InOutElastic);
        yield return null;
    }


    public IEnumerator LifeChangeText(int value)
    {
        int verticalSlide = (value < 0) ? -9 : 9;
        _lifeText.gameObject.transform.localPosition = new Vector3(_lifeTextPosition.x, _lifeTextPosition.y - verticalSlide * 2);
        _lifeText.text = (value < 0) ? value.ToString() : "+" + value.ToString();
        _lifeText.color = (value < 0) ? _substractionColor : _additionColor;
        _lifeText.DOFade(1, 0.5f);
        _lifeText.gameObject.transform.DOLocalMoveY(_lifeTextPosition.y + verticalSlide / 2, 0.5f);
        yield return new WaitForSeconds(0.8f);
        _lifeText.DOFade(0, 0.5f);
        _lifeText.gameObject.transform.DOLocalMoveY(_lifeTextPosition.y + verticalSlide * 2, 0.5f);
    }

    public IEnumerator HungerChangeText(int value)
    {
        int verticalSlide = (value < 0) ? -9 : 9;
        _hungerText.gameObject.transform.localPosition = new Vector3(_hungerTextPosition.x, _hungerTextPosition.y - verticalSlide * 2);
        _hungerText.text = (value < 0) ? value.ToString() : "+" + value.ToString();
        _hungerText.color = (value < 0) ? _substractionColor : _additionColor;
        _hungerText.DOFade(1, 0.5f);
        _hungerText.gameObject.transform.DOLocalMoveY(_hungerTextPosition.y + verticalSlide / 2, 0.5f);
        yield return new WaitForSeconds(0.8f);
        _hungerText.DOFade(0, 0.5f);
        _hungerText.gameObject.transform.DOLocalMoveY(_hungerTextPosition.y + verticalSlide * 2, 0.5f);
    }

    private void Awake()
    {
        _lifeLogo = this.transform.Find("Life").Find("Logo").gameObject;
        _hungerLogo = this.transform.Find("Hunger").Find("Logo").gameObject;

        _lifeText = this.transform.Find("Life").Find("Amount").GetComponent<TextMeshProUGUI>();
        _lifeTextPosition = _lifeText.gameObject.transform.localPosition;

        _hungerText = this.transform.Find("Hunger").Find("Amount").GetComponent<TextMeshProUGUI>();
        _hungerTextPosition = _hungerText.gameObject.transform.localPosition;
    }
}
