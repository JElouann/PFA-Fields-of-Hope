using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GFSettingsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _settingsButtonsParent;
    [SerializeField] private GameObject _enterSettingsButton;
    [SerializeField] private GameObject _exitSettingsButton;

    private static bool _isInSettings;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void GameFeelOnClick()
    {
        if (_isInSettings)
        {
            _isInSettings = false;
            _settingsButtonsParent.transform.DOLocalMoveX(_settingsButtonsParent.transform.localPosition.x - 75, 0.75f);
            _enterSettingsButton.GetComponent<Button>().interactable = true;
            _exitSettingsButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            _isInSettings = true;
            _settingsButtonsParent.transform.DOLocalMoveX(_settingsButtonsParent.transform.localPosition.x + 75, 0.75f);
            _exitSettingsButton.GetComponent<Button>().interactable = true;
            _enterSettingsButton.GetComponent<Button>().interactable = false;
        }
    }
}
