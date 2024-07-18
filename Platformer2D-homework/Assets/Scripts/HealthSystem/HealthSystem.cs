using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _health;

    public event Action<float> СhangeHealth;
 
    public float Health => _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void SetHealth()
    {
        СhangeHealth?.Invoke(_health);
    }

    public void TakeHealthy(float health)
    {
        _health += health;

        if (_health > _maxHealth)
            _health = _maxHealth;

        Debug.Log("Я восполняю здоровье теперь оно равно " + _health);

        SetHealth();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;

        Debug.Log("Получен урон текущее здоровье равно " + _health);

        SetHealth();
    }
}
