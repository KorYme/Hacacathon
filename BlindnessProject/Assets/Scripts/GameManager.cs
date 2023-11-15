using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance ??= this;
    }

    [SerializeField] UnityEvent _onStart;

    void Start()
    {
        _onStart?.Invoke();
    }
}
