using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public enum Type
{
    Farm,
    Exploration
}

public class DayChoice : MonoBehaviour
{
    private DayManager _dayManager;
    private event Action OnChoose;

    [SerializeField] private GameObject _cultureMenu;

    private EventInstancier _eventInstancier;

    [Header("Boutons")]
    [SerializeField] private GameObject _farmButton;
    [SerializeField] private GameObject _explorationButton;

    private Vector3 _farmButtonPosition;
    private Vector3 _explorationButtonPosition;

    public static bool _selected { get; private set; }

    public void SelectFarm()
    {
        if(_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Farm;
            OnChooseDailyTask();
            Debug.Log($"<color=green>{_dayManager.DayChoice} </color>");
        }
    }

    public void SelectExploration()
    {
        if (_dayManager.DayChoice == DailyChoice.None)
        {
            _dayManager.DayChoice = DailyChoice.Exploration;
            OnChooseDailyTask();
            Debug.Log($"<color=orange>{_dayManager.DayChoice} </color>");
        }
    }

    private void OnChooseDailyTask()
    {
        _selected = true;
        switch (_dayManager.DayChoice)
        {
            case DailyChoice.Farm:
                _farmButton.SendMessage("SelectedGameFeel", -1);
                _farmButton.GetComponent<Button>().interactable = false;
                _explorationButton.SendMessage("NotSelectedGameFeel");
                _cultureMenu.SetActive(true);
                _cultureMenu.GetComponentInChildren<DialogueBox>().StartDialogue("Je suis à la ferme. Bon, quel légume planter ?");
                break;
            
            case DailyChoice.Exploration:
                _explorationButton.SendMessage("SelectedGameFeel", 1);
                _explorationButton.GetComponent<Button>().interactable = false;
                _farmButton.SendMessage("NotSelectedGameFeel");

                _eventInstancier.InstantiateEvent(EventType.Expedition);
                break;
        }
    }

    private void Start()
    {
        _eventInstancier = GameObject.Find("EventInstancier").GetComponent<EventInstancier>();
        _dayManager = GameObject.Find("DayManager").GetComponent<DayManager>();
        _farmButtonPosition = this._farmButton.transform.position;
        _explorationButtonPosition = this._explorationButton.transform.position;
    }

    public void Restart()
    {
        _selected = false;

        _farmButton.SetActive(true);
        _farmButton.GetComponent<Button>().interactable = true;
        _farmButton.transform.position = _farmButtonPosition;
        _farmButton.transform.localScale = Vector3.one;
        _farmButton.GetComponent<Image>().DOFade(1, 0);
        _farmButton.transform.GetChild(0).GetComponent<Image>().DOFade(1, 0f);

        _explorationButton.SetActive(true);
        _explorationButton.GetComponent<Button>().interactable = true;
        _explorationButton.transform.position = _explorationButtonPosition;
        _explorationButton.transform.localScale = Vector3.one;
        _explorationButton.GetComponent<Image>().DOFade(1, 0);
        _explorationButton.transform.GetChild(0).GetComponent<Image>().DOFade(1, 0f);
    }
}