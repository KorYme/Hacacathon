using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Answer
{
    public bool IsTheGoodAnswer;
    [TextArea(3, 10)] public string AnswerData;
}

[CreateAssetMenu]
public class QCM_Questions : ScriptableObject
{
    [TextArea(3, 10)] public string question;
    [Space] 
    public List<Answer> answers;
}
