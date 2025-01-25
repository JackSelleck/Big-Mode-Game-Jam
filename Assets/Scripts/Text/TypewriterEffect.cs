using System;
using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TypewriterEffect : MonoBehaviour /// Creates the "typewriter effect" on text you put it on
{
    // The text 
    private TMP_Text _textBox;

    // Basic typewriter functionality 
    private int _currentVisibleCharacterIndex;
    private Coroutine _typewriterCorutine;
    private bool _readyForNewText = true;

    // delay between letters and punctuation
    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpunctuationDelay;

    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float interpunctuationDelay = 0.5f;

    // Skipping Functionality
    public bool CurrentlySkipping { get; private set; }
    private WaitForSeconds _skipDelay;

    [Header("Skip Options")]
    [SerializeField] private bool _quickSkip;
    [SerializeField][Min(1)] private int _skipSpeedup = 5;

    // Event Functionality, allows other scrips to have info on the typewriter
    private WaitForSeconds _textboxFullEventDelay;
    [SerializeField][Range(0.1f, 0.5f)] private float sendDoneDelay = 0.25f;

    public static event Action CompleteTextRevealed;
    public static event Action<char> CharacterRevealed;

    private void Awake()
    {
        _textBox = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _interpunctuationDelay = new WaitForSeconds(interpunctuationDelay);

        _skipDelay = new WaitForSeconds(1 / (charactersPerSecond * _skipSpeedup));
        _textboxFullEventDelay = new WaitForSeconds(sendDoneDelay);
    }

    private void OnEnable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(SetText);
    }

    private void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(SetText);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    // Checks when the player clicks to speed up
    private void OnClick()
    {
        if (_textBox.maxVisibleCharacters != _textBox.textInfo.characterCount - 1)
        {
            Skip();
            Debug.Log("Text Skipped");
        }
    }

    private void Skip()
    {
        // If already skipping then the skip code will not run
        if (CurrentlySkipping)
            return;

        CurrentlySkipping = true;

        if (!_quickSkip)
        {
            StartCoroutine(SkipSpeedupReset());
            return;
        }

        StopCoroutine(_typewriterCorutine);
        _textBox.maxVisibleCharacters = _textBox.textInfo.characterCount;
        // _readyForNewText = true;
        // The question mark makes it check if it is null before invoking which stops null reference exceptions
        CompleteTextRevealed?.Invoke();
    }

    private IEnumerator SkipSpeedupReset()
    {
        yield return new WaitUntil(() => _textBox.maxVisibleCharacters == _textBox.textInfo.characterCount - 1);
        CurrentlySkipping = false;
    }

    public void SetText(object obj)
    {
        if (!_readyForNewText)
        {
            return;
        }

        _readyForNewText = false;

        // Stops the typewriter coroutine from giving an error when all text has been displayed
        if (_typewriterCorutine != null)
        {
            StopCoroutine(_typewriterCorutine);
        }

        _textBox.maxVisibleCharacters = 0;
        _currentVisibleCharacterIndex = 0;

        _typewriterCorutine = StartCoroutine(Typewriter());
    }

    private IEnumerator Typewriter()
    {
        TMP_TextInfo textInfo = _textBox.textInfo;

        while (_currentVisibleCharacterIndex < textInfo.characterCount + 1)
        {
            var lastCharacterIndex = textInfo.characterCount - 1;

            if (_currentVisibleCharacterIndex == lastCharacterIndex)
            {
                _textBox.maxVisibleCharacters++;
                yield return _textboxFullEventDelay;
                CompleteTextRevealed?.Invoke();
                // _readyForNewText = true;
                yield break;
            }

            char character = textInfo.characterInfo[_currentVisibleCharacterIndex].character;

            _textBox.maxVisibleCharacters++;

            if (!CurrentlySkipping &&
               ((character == '?' || character == '.' || character == ',' || character == ':'
               || character == ';' || character == '!' || character == '-')))
            {
                yield return _interpunctuationDelay;
            }
            else
            {   // could also be written as "yield return CurrentlySkipping ? _skipDelay : _simpleDelay;", but i think this is more readable

                if (CurrentlySkipping) yield return _skipDelay;

                else yield return _simpleDelay;
            }

            CharacterRevealed?.Invoke(character);
            _currentVisibleCharacterIndex++;

        }
    }
}
