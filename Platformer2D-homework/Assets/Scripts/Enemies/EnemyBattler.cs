using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyBattler), typeof(EnemyPartol))]
public class EnemyBattler : MonoBehaviour
{
    [SerializeField] private Text _healthOnScreen;
    [SerializeField, Min(1)] private float _damage;
    [SerializeField, Range(1f, 20f)] private float _armor;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private LayerMask _player;
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

        if (_isAttack == false && GetComponent<EnemyPartol>().IsPursuit == true)
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

    private void Attack()
    {       
        _isAttack = true;
        Collider2D[] players = Physics2D.OverlapCircleAll(_attackPosition.position, _radiusAttack, _player);

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerBattler>().TakeDamage(_damage);
        }

        StartCoroutine(AttackCoolDown());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPosition.position, _radiusAttack);
    }

    private IEnumerator AttackCoolDown()
    {
        var duration = new WaitForSeconds(_attackCoolDown);

        yield return duration;

        _isAttack = false;
    }
}
