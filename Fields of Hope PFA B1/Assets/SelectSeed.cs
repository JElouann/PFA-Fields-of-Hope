using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectSeed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SO_SeedsData SO_SeedsData;

    [SerializeField]
    FarmManager seedsPlants;

    public Image Image;

    public TextMeshProUGUI textDescription;

    public GameObject textBox;

    public void SelectedSeed()
    {
        seedsPlants.seedData = SO_SeedsData;
        textBox.GetComponent<DialogueBox>().StartDialogue(SO_SeedsData.Description);
    }

    public void Start()
    {
        Image.sprite = SO_SeedsData.Image ;

    }


    #region GameFeel
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.DOScale(this.transform.localScale * 1.2f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.DOScale(new Vector3 (0.009259259f, 0.009259259f, 0.009259259f), 0.3f);
    }
    #endregion
}
