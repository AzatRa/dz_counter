using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [Header("Cherez skol'ko povtoryat'?")]
    [SerializeField] private float _repeatRate = 0.5f;
    [Header("Skol'ko pribavlyat'?")]
    [SerializeField] private int _value = 1;
    [Header("Knopka dlya upravleniya.")]
    [SerializeField] private Button _button;

    private Coroutine _coroutine;
    private int _currentCount;
    private int _count = 0;
    private bool _isRunning = true;

    public int CurrentValue => _currentCount;

    public event Action<int> ValueChanged;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void Start()
    {
        Restart();
    }

    public void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _isRunning = false;
    }

    public void Restart()
    {
        Stop();
        _isRunning = true;
        _coroutine = StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        var wait = new WaitForSecondsRealtime(_repeatRate);

        while (_isRunning)
        {
            _count++;
            _currentCount = _count * _value;
            ValueChanged?.Invoke(_currentCount);
            yield return wait;
        }
    }

    private void OnButtonClicked()
    {
        if (_isRunning)
        {
            Stop();
        }
        else
        {
            Restart();
        }
    }    
}
