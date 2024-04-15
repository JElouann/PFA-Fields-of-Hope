using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [SerializeField] private float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;

    [SerializeField] private Sprite _leftPageSprite;
    [SerializeField] private Sprite _rightPageSprite;

    [SerializeField] private GameObject _pageLeftPrevab;


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
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true);
        }
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false);
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
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false);
        }
    }

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
    public void CreatePage()
    {
        //GameObject newPage = Instantiate()
    }
    #endregion

    private void Start()
    {
        backButton.SetActive(false);
    }
}
