using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerBattler))]
public class PlayerBattler : MonoBehaviour
{
    [SerializeField] private Text _healthOnScreen;
    [SerializeField, Min(1)] private float _damage;
    [SerializeField, Range(1f, 20f)] private float _armor;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private float _attackCoolDown;

    private float _maxArmorPercentage = 100;
    private float _maxHealth = 100;
    private float _health;
    private bool _isAttack = false;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _healthOnScreen.text = ("HP: " + _health.ToString());

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

        if (Input.GetMouseButton(0) && _isAttack == false)
        {
            Attack();            
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage * ((_maxArmorPercentage - _armor) / _maxArmorPercentage);
        
        if (_health < 0)
            _health = 0;
    }

    public void TakeHealthy(float health)
    {
        _health += health;

        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPosition.position, _radiusAttack, _enemy);
        _isAttack = true;

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyBattler>().TakeDamage(_damage);
        }

        StartCoroutine(AttackCoolDown());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (_attackPosition.position, _radiusAttack);
    }

    private IEnumerator AttackCoolDown()
    {
        var duration = new WaitForSeconds(_attackCoolDown);     
        
        yield return duration;

        _isAttack = false;
    }
}
