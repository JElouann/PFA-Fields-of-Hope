using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    [field: SerializeField]
    public string[] Lines { get; private set; } = new string[0];

    [SerializeField] private float _textSpeed = 0.3f;
    [SerializeField] private int _index;

    [SerializeField] private TextSlicer _textSlicer;

    public event Action OnEndTextDisplay;

    private Coroutine _dialogueCoroutine;

    [SerializeField]
    private AudioClip _Sound;

    private SoundSFXManager _soundSFXManager;

    private void Awake()
    {
        _soundSFXManager = FindAnyObjectByType<SoundSFXManager>();    
    }

    public void StartDialogue(string text)
    {
        _soundSFXManager.PlaySoundFXClip(_Sound, transform, 1f, "Music");
        _textSlicer = gameObject.GetComponent<TextSlicer>();
        Lines = _textSlicer.Slice(text).ToArray();

        _index = -1;

        NextLine();
    }

    private IEnumerator TypeLine()
    {
        //this.GetComponent<Button>().interactable = false; VERSION SANS GAME FEEL
        Button button = GameObject.Find("Button").GetComponent<Button>();
        //button.interactable = false;
        _text.text = Lines[_index];
        _text.maxVisibleCharacters = 0;
        for (int i = 0; i < Lines[_index].Length; i++)
        {
            _text.maxVisibleCharacters++;
            yield return new WaitForSeconds(_textSpeed);
        }

        if (_index == Lines.Length - 1)
        {
            //this.GetComponent<Button>().interactable = false;
            //button.interactable = false;
            // afficher potentiels bouttons choix
            this.OnEndTextDisplay?.Invoke();

        }
        else
        {
            //this.GetComponent<Button>().interactable = true;
            button.interactable = true;
        }
        _dialogueCoroutine = null;
    }

    public void NextLine()
    {
        if (_index >= Lines.Length - 1) return;

        if (_dialogueCoroutine != null && _index != -1)
        {
            //if (_index == -1) print("ouais le couscous");
            StopCoroutine(_dialogueCoroutine);
            _dialogueCoroutine = null;
            _text.maxVisibleCharacters = Lines[_index].Length;
        }
        else
        {
            _index++;
            _dialogueCoroutine = StartCoroutine(TypeLine());
        }
    }
}