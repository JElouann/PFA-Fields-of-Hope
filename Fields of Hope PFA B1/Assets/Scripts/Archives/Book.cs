using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    // Settings
    [SerializeField] float pageSpeed = 0.5f;

    // System
    [SerializeField] private GameObject _page;
    [SerializeField] private GameObject _book;
    private GameObject _recto;
    private GameObject _verso;

    private Coroutine FlipPageCoroutine;

    private void Start()
    {
        _recto = _page.transform.GetChild(0).Find("Recto").gameObject;
        _verso = _page.transform.GetChild(0).Find("Verso").gameObject;
    }

    private bool _isFlipped;

    public void TurnPage()
    {
        FlipPageCoroutine = StartCoroutine(FlipPage());
    }

    private IEnumerator FlipPage()
    {
        if (FlipPageCoroutine != null) { StopCoroutine(FlipPageCoroutine); }

        if (_isFlipped)
        {
            _page.transform.DORotate(new Vector3(_page.transform.rotation.x, 90, _page.transform.rotation.z), pageSpeed);
            yield return new WaitForSeconds(pageSpeed / 2);
            if(FlipPageCoroutine != null) { FlipPageCoroutine = null; }
            _book.transform.DOPunchScale(new Vector3(0.0125f, 0, 0), pageSpeed / 2, 0).SetEase(Ease.InBack);
            _verso.SetActive(true);
            _recto.SetActive(false);
            _page.transform.DORotate(new Vector3(_page.transform.rotation.x, 0, _page.transform.rotation.z), pageSpeed);
            _isFlipped = false;
        }
        else
        {
            _page.transform.DORotate(new Vector3(_page.transform.rotation.x, 90, _page.transform.rotation.z), pageSpeed);
            yield return new WaitForSeconds(pageSpeed / 2);
            if (FlipPageCoroutine != null) { FlipPageCoroutine = null; }
            _book.transform.DOPunchScale(new Vector3(0.0125f, 0, 0), pageSpeed / 2, 0);
            _verso.SetActive(false);
            _recto.SetActive(true);
            _page.transform.DORotate(new Vector3(_page.transform.rotation.x, 180, _page.transform.rotation.z), pageSpeed);
            _isFlipped = true;
        }
    }
}