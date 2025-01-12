using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //private float _maxHealth = 100;
    //private float _health;

    //public event Action<float> �hangeHealth;

    //public float Health => _health;

    //private void Awake()
    //{
    //    _health = _maxHealth;
    //}

    //private void SetHealth()
    //{
    //    �hangeHealth?.Invoke(_health);
    //}

    //public void TakeHealthy(float health)
    //{
    //    _health += health;

    //    if (_health > _maxHealth)
    //        _health = _maxHealth;

    //    Debug.Log("� ��������� �������� ������ ��� ����� " + _health);

    //    SetHealth();
    //}

    //public void TakeDamage(float damage)
    //{
    //    _health -= damage;

    //    if (_health < 0)
    //        _health = 0;

    //    Debug.Log("������� ���� ������� �������� ����� " + _health);

    //    SetHealth();
    //}
    public event Action<float> �hangeHealthPoint;
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

        Debug.Log("� ��������� �������� ������ ��� ����� " + _health);

        SetHealth();
    }

    public void SubtractHealthPoint(float healtPoint)
    {
        _health -= healtPoint;

        if (_health < 0)
            _health = 0;

        Debug.Log("������� ���� ������� �������� ����� " + _health);

        SetHealth();
    }

    private void SetHealth()
    {
        �hangeHealthPoint?.Invoke(_health);
        SetHealthPoint?.Invoke();
    }
}
