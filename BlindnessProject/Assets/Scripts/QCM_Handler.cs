using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QCM_Handler : MonoBehaviour
{
    [SerializeField] List<QCM_Questions> _questions;
    [SerializeField] TMP_Text _questionText;
    [SerializeField] List<TMP_Text> _answersText;

    [SerializeField] float _initialFontSize;
    [SerializeField] float _sizeModifier;
    [SerializeField] Vector2 _sizeClamp;

    float _currentFontDelta;
    int _questionCount;
    int _numberOfAnswer;

    private void Reset()
    {
        _initialFontSize = .5f;
        _sizeModifier = .1f;
        _sizeClamp = new Vector2(.1f, 1f);
        _answersText = new List<TMP_Text>();
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Answer"))
            {
                _answersText.Add(child.GetComponent<TMP_Text>());
            }
            else
            {
                _questionText = child.GetComponent<TMP_Text>();
            }
        }
    }

    private void Start()
    {
        _questionCount = -2;
        _currentFontDelta = 0f;
        _numberOfAnswer = transform.childCount - 1;
        foreach (var question in _answersText)
        {
            question.fontSize = _initialFontSize + _currentFontDelta;
        }
        RemoveAllQuestions();
    }

    public void CheckSliderValue(Slider slider)
    {
        if (slider.value < 1f) return;        
        DisplayQuestions();
    }

    public void DisplayQuestions()
    {
        if (_questions.Count == 0 || _questionCount != -2 || !enabled) return;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        _questionCount = -1;
        InitializeNewQuestion();
    }

    private void RemoveAllQuestions()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void InitializeNewQuestion()
    {
        if (_questionCount == _questions.Count - 1) 
        {
            _questionCount = -2;
        }

        if (_questionCount == -2)
        {
            
            RemoveAllQuestions();
            enabled = false;
            return;
        }

        _questionCount++;
        _questionText.text = _questions[_questionCount].question;
        for (int i = 0; i < _numberOfAnswer; i++)
        {
            _answersText[i].text = _questions[_questionCount].answers[i].AnswerData;
        }
    }
    
    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex >= _numberOfAnswer) return;
        ChangeFontSize(_questions[_questionCount].answers[answerIndex].IsTheGoodAnswer);
        InitializeNewQuestion();
    }

    private void ChangeFontSize(bool isIncreasing)
    {
        _currentFontDelta = Mathf.Clamp(_currentFontDelta + _sizeModifier * (isIncreasing ? 1 : -1), _sizeClamp.x, _sizeClamp.y);
        foreach (TMP_Text answer in _answersText)
        {
            answer.fontSize = _initialFontSize + _currentFontDelta;
        }
        _questionText.fontSize = _initialFontSize + _currentFontDelta;
    }
}
