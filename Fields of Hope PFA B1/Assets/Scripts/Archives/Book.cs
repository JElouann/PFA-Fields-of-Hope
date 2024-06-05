using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    // Sprites
    [SerializeField] private Sprite _rectoSprite;
    [SerializeField] private Sprite _versoSprite; 

    // Settings
    [SerializeField] float pageSpeed = 0.5f;

    // System
    [SerializeField] GameObject page;
    private GameObject _recto;
    private GameObject _verso;
    int index = -1;
    bool rotate = false;

    // Buttons [TEMPORARY]
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;

    private void Start()
    {
        print(_isFlipped);
        _recto = page.transform.GetChild(0).Find("Recto").gameObject;
        _verso = page.transform.GetChild(0).Find("Verso").gameObject;
        //InitialState();
    }

    public void InitialState()
    {
        page.transform.rotation = new Quaternion(0, 0, 0, 0);
        _recto.SetActive(false);
        _recto.transform.SetAsLastSibling();
        forwardButton.SetActive(false);

    }

    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 0; //in order to rotate the page forward, you need to set the rotation by 180 degrees around the y axis
        ForwardButtonActions();
        page.transform.SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));

    }

    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true); //every time we turn the page forward, the back button should be activated
        }
        /*if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false); //if the page is last then we turn off the forward button
        }*/
    }

    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 180; //in order to rotate the page back, you need to set the rotation to 0 degrees around the y axis
        //pages[index].transform.SetAsLastSibling();
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true); //every time we turn the page back, the forward button should be activated
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false); //if the page is first then we turn off the back button
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            if(page.transform.rotation.y == -86.957f) //-85 > page.transform.rotation.y && page.transform.rotation.y > -95
            {
                //_recto.SetActive(true);
                print("�tape");
            }
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            page.transform.rotation = Quaternion.Slerp(page.transform.rotation, targetRotation, value); //smoothly turn the page
            float angle1 = Quaternion.Angle(page.transform.rotation, targetRotation); //calculate the angle between the given angle of rotation and the current angle of rotation
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

    private bool _isFlipped;

    public void TurnPage() // TRANSFORMER EN ASYNC OU COROUTINE POUR REGLER TIMING
    {
        /*if (_isFlipped)
        {
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 90, page.transform.rotation.z), pageSpeed);
            _verso.SetActive(true);
            _recto.SetActive(false);
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 0, page.transform.rotation.z), pageSpeed);
            _isFlipped = false;
        }
        else
        {
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 90, page.transform.rotation.z), pageSpeed);
            _verso.SetActive(false);
            _recto.SetActive(true);
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 180, page.transform.rotation.z), pageSpeed);
            _isFlipped = true;
        }
        print(_isFlipped);*/

        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        if (_isFlipped)
        {
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 90, page.transform.rotation.z), pageSpeed);
            yield return new WaitForSeconds(pageSpeed / 2);
            _verso.SetActive(true);
            _recto.SetActive(false);
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 0, page.transform.rotation.z), pageSpeed);
            _isFlipped = false;
        }
        else
        {
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 90, page.transform.rotation.z), pageSpeed);
            yield return new WaitForSeconds(pageSpeed /2);
            _verso.SetActive(false);
            _recto.SetActive(true);
            page.transform.DORotate(new Vector3(page.transform.rotation.x, 180, page.transform.rotation.z), pageSpeed);
            _isFlipped = true;
        }
        print(_isFlipped);
    }

}