using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [SerializeField] private float pageSpeed = 0.5f;
    [SerializeField] public List<Transform> pages;

    public int index { get; private set; } = -1;
    private bool rotate = false;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _forwardButton;

    [SerializeField] private Sprite _leftPageSprite;
    [SerializeField] private Sprite _rightPageSprite;

    #region UI
    public void RotateNext()
    {
        if (rotate) { return; }
        index++;
        float angle = 180;
        
        pages[index].SetAsLastSibling();
        ForwardButtonActions();
        StartCoroutine(Rotate(angle, true));
    }

    public void ForwardButtonActions()
    {
        if (_backButton.activeInHierarchy == false)
        {
            _backButton.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            _forwardButton.SetActive(false);
        }
    }

    public void RotateBack()
    {
        if (rotate) { return; }
        float angle = 0f;
        pages[index].SetAsLastSibling();
        BackButtonActions();
        StartCoroutine (Rotate(angle, false));
    }

    public void BackButtonActions()
    {
        if (_forwardButton.activeInHierarchy == false)
        {
            _forwardButton.SetActive(true);
        }
        if (index - 1 == -1)
        {
            _backButton.SetActive(false);
        }
    }

    /// <summary>
    /// Coroutine that rotate the page forward or backward over the time.
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="forward"></param>
    /// <returns></returns>
    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while(true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);

            // distinction between recto and verso
            if (pages[index].rotation.y >= -0.8f && !forward)
            {
                pages[index].Find("verso").SetAsFirstSibling();
            }
            else if (pages[index].rotation.y <= -0.6f && forward)
            {
                pages[index].Find("verso").SetAsLastSibling();
            }
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }
    #endregion UI

    #region System
    
    #endregion

    private void Start()
    {
        _backButton.SetActive(false);
    }
}
