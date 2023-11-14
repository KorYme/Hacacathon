using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent _onStart;
    [SerializeField] float _startingFontSize;
    [SerializeField] UnityEvent<float> _onFontSizeChanged;

    float _currentFontSize;
    public float CurrentFontSize
    {
        get => _currentFontSize;
        set
        {
            _currentFontSize = value;
            _onFontSizeChanged?.Invoke(value);
        }
    }

    void Start()
    {
        _onStart?.Invoke();
        CurrentFontSize = _startingFontSize;
    }
}
