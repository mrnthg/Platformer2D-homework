using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyBattler), typeof(EnemyPartol), typeof(HealthSystem))]
public class EnemyBattler : MonoBehaviour
{
    [SerializeField] private Text _healthOnScreen;
    [SerializeField, Min(1)] private float _damage;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private LayerMask _layerMaskPlayer;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private float _attackCoolDown;

    private bool _isAttack = false;
    private EnemyPursuit _enemyPursuit;
    private HealthSystem _healthSystem;

    private void Start()
    {
        _enemyPursuit = GetComponent<EnemyPursuit>();
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        if (_isAttack == false && _enemyPursuit.IsPursuit == true)
        {
            Attack();
            Debug.Log("Враг наносит удар");
        }      
        
        if (_healthSystem.Health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Attack()
    {       
        _isAttack = true;
        Collider2D[] players = Physics2D.OverlapCircleAll(_attackPosition.position, _radiusAttack, _layerMaskPlayer);

        for (int i = 0; i < players.Length; i++)
        {        
            if (players[i].TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.TakeDamage(_damage);
            }
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
