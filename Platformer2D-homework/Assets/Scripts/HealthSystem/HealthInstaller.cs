using System;
using UnityEngine;

public class HealthInstaller : MonoBehaviour
{
    public event Action<float> ChangeHealthPoint;
    public event Action SetHealthPoint;

    private float _maxHealthPoint = 100;
    private float _health;

    public float Health => _health;
    public float MaxHealthPoint => _maxHealthPoint;

    private void Awake()
    {
        _health = _maxHealthPoint;
    }

    public void AddHealthPoint(float healtPoint)
    {
        _health += healtPoint;

        if (_health > _maxHealthPoint)
            _health = _maxHealthPoint;

        SetHealth();
    }

    public void SubtractHealthPoint(float healtPoint)
    {
        _health -= healtPoint;

        if (_health < 0)
            _health = 0;

        SetHealth();
    }

    private void SetHealth()
    {
        ChangeHealthPoint?.Invoke(_health);
        SetHealthPoint?.Invoke();
    }
}
