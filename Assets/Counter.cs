using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [Header("Через сколько повторять?")]
    [SerializeField] private float _repeatRate = 0.5f;
    [Header("Сколько прибавлять?")]
    [SerializeField] private int _value = 1;
    [Header("Кпопка для управления.")]
    [SerializeField] private Button _button;

    private Coroutine _coroutine;
    private int _currentCount;
    private int count = 0;
    private bool _isRunning = true;

    public int CurrentCount => _currentCount;

    public event Action<int> CountChanged;

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
        _coroutine = StartCoroutine(CounterCoroutine());
    }

    private IEnumerator CounterCoroutine()
    {
        var wait = new WaitForSecondsRealtime(_repeatRate);

        while (_isRunning)
        {
            count++;
            _currentCount = count * _value;
            CountChanged?.Invoke(_currentCount);
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
