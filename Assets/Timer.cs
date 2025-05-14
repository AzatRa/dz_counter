using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [Header("Через сколько повторять?")]
    [SerializeField] private float _repeatRate = 0.5f;
    [Header("Сколько прибавлять?")]
    [SerializeField] private float _value = 1.0f;
    [Header("Кпопка для управления.")]
    [SerializeField] private Button _button;

    private Coroutine _coroutine;

    private int _currentCount = 0;
    private bool _isRunning = true;

    private void Start()
    {
        _text.text = "";
        Restart();
    }

    public void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _isRunning = false;
        Debug.Log("Stop coroutine");
    }

    public void Restart()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Counter());
        _isRunning = true;
        Debug.Log("Restart coroutine");
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
        Debug.Log("AddListener(OnButtonClicked).");
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
        Debug.Log("RemoveListener(OnButtonClicked).");
    }

    private IEnumerator Counter()
    {
        var wait = new WaitForSecondsRealtime(_repeatRate);

        while (true)
        {
            _currentCount++;
            DisplayTimer(_currentCount);
            yield return wait;
        }
    }

    private void DisplayTimer(int count)
    {
        _text.text = (count * _value).ToString("");
    }

    private void OnButtonClicked()
    {
        Debug.Log("Button clicked");

        if (_isRunning)
        {
            Stop();
            Debug.Log("Stoped");
        }
        else
        {
            Restart();
            Debug.Log("Restarted");
        }
    }
}
