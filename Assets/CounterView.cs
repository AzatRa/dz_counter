using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private int _lastCount = -1;

    private void OnEnable()
    {
        _counter.CountChanged += OnCountChanged;

        DisplayCounter(_counter.CurrentCount);
    }

    private void OnDisable()
    {
        _counter.CountChanged -= OnCountChanged;
    }

    private void OnCountChanged(int newCount)
    {
        DisplayCounter(newCount);
        _lastCount = newCount;
    }

    private void DisplayCounter(int count)
    {
        if (_text != null)
        {
            _text.text = count.ToString();
        }
        else
        {
            Debug.LogWarning("_text is null");
        }
    }
}
