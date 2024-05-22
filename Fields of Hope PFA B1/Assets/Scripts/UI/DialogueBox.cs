using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    [field: SerializeField]
    public string[] Lines {  get; private set; } = new string[0];

    [SerializeField] private float _textSpeed = 0.3f;
    private int _index;

    [SerializeField] private TextSlicer _textSlicer;

    public event Action OnEndTextDisplay;

    public void StartDialogue(string text)
    {
        
        _textSlicer = gameObject.GetComponent<TextSlicer>();
        Lines = _textSlicer.Slice(text).ToArray();

        _text.text = string.Empty;
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        this.GetComponent<Button>().interactable = false;
        foreach (char c in Lines[_index].ToCharArray())
        {
            _text.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
        if (_index == Lines.Length - 1)
        {
            this.GetComponent<Button>().interactable = false;
            // afficher potentiels bouttons choix
            this.OnEndTextDisplay?.Invoke();
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }

    public void NextLine()
    {
        if (_index < Lines.Length - 1)
        {
            _index++;
            _text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
