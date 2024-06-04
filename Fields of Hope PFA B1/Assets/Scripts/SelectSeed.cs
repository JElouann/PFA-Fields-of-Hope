using System.Drawing;
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

    [SerializeField] 
    private TextMeshProUGUI _textAffichage;

    public void SelectedSeed()
    {
        if (seedsPlants.seedData == SO_SeedsData) return;
        seedsPlants.seedData = SO_SeedsData;
        _textAffichage.text = SO_SeedsData.name + "\n" + "Nombre de graine nécessaire : "+ "<color=#D14E4E>" + "-" + SO_SeedsData.CoutEnGraines + "</color>" + "\n" + "Temps de pousse : " + SO_SeedsData.TempsDePousseEnJours + " jour" + "\n" + "Taux de Satiété :" + "<color=#6FA048>"+ "+"  + SO_SeedsData.Satiété + "</color>";
        textBox.GetComponent<DialogueBox>().StartDialogue(_textAffichage.text);
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
