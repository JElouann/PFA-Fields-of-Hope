using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageInstancier : MonoBehaviour
{
    [SerializeField] private Book _book;
    [SerializeField] private GameObject _pageLeftPrefab;
    [SerializeField] private GameObject _pageRightPrefab;
    [SerializeField] private List<string> _paragraphes;
    [SerializeField] private List<string> _paragraphes2;
    [SerializeField] private List<string> _paragraphes3;

    [SerializeField] private Transform _parent;

    public void CreateRightPage(List<string> paragraphes)
    {
        GameObject newPage = Instantiate(_pageRightPrefab, _parent);
        //TextMeshProUGUI newPageContent = newPage.transform.Find("Droite").transform.Find("content").GetComponent<TextMeshProUGUI>();
        
        foreach (string s in paragraphes)
        {
            //newPageContent.text += "<br>" + s;
        }
        _book.pages.Add(newPage.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateRightPage(_paragraphes);
        //CreateRightPage(_paragraphes2);
        //CreateRightPage(_paragraphes3);
        
    }
}
