using TMPro;
using UnityEngine;

public class Realtime : MonoBehaviour
{
    [Header("—чЄтчик реального времени")]
    [SerializeField] private TextMeshProUGUI _realtimeText;

    private float _realtimeDelay = 1.0f;
    private float _realtimeRepeatRate = 1.0f;

    private void Start()
    {
        _realtimeText.text = "0";
        InvokeRepeating(nameof(SetCurrentTime), _realtimeDelay, _realtimeRepeatRate);
    }

    private void SetCurrentTime()
    {
        _realtimeText.text = Time.time.ToString("");
    }
}
