using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarHealthDisplay : HealthView
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField, Min(1f)] private float _lerpSpeed;

    public override HealthSystem HealthSystem
    {
        get
        {
            return _healthSystem;
        }
    }

    private void OnEnable()
    {
        _healthSystem.SetHealthPoint += SetHealth;
    }

    private void OnDisable()
    {
        _healthSystem.SetHealthPoint -= SetHealth;
    }

    protected override void SetHealth()
    {
        float endValue = _healthSystem.Health / _healthSystem.MaxHealthPoint;

        StartCoroutine(HealthProgress(endValue));
    }

    private IEnumerator HealthProgress(float endValue)
    {
        float elapsed = 0;
        float lerpDuration = 0f;

        while (elapsed < _lerpSpeed)
        {
            lerpDuration += Time.deltaTime;
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, endValue, lerpDuration / _lerpSpeed);
            elapsed += lerpDuration;

            yield return null;
        }
    }
}
