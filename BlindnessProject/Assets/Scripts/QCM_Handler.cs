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

    float _currentFontDelta = 0f;
    int _questionCount = -2;

    private void Start()
    {
        _questionCount = -2;
        _currentFontDelta = 0f;
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
        for (int i = 0; i < 4; i++)
        {
            _answersText[i].text = _questions[_questionCount].answers[i].AnswerData;
        }
    }
    
    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex >= 4) return;
        ChangeFontSize(_questions[_questionCount].answers[answerIndex].IsTheGoodAnswer);
        InitializeNewQuestion();
    }

    private void ChangeFontSize(bool isIncreasing)
    {
        _currentFontDelta += _sizeModifier * (isIncreasing ? 1 : -1);
        foreach (var question in _answersText)
        {
            question.fontSize = _initialFontSize + _currentFontDelta;
        }
    }
}
