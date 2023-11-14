using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QCM_Handler : MonoBehaviour
{
    [SerializeField] List<QCM_Questions> _questions;
    [SerializeField] List<TMP_Text> _questionsText;

    int _questionCount = 0;

    public void InitializeNewQuestion()
    {
        if (_questionCount == -1) return;

        for (int i = 0; i < 4; i++)
        {
            _questionsText[i].text = _questions[_questionCount]._answers[i].AnswerData;
        }

        _questionCount++;
        if (_questionCount == _questions.Count) _questionCount = -1;
    }
}
