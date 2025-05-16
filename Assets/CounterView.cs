using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.ValueChanged += OnCountChanged;

        DisplayCounter(_counter.CurrentValue);
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnCountChanged;
    }

    private void OnCountChanged(int newCount)
    {
        DisplayCounter(newCount);
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
