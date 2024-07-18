using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerBattler), typeof(HealthSystem))]
public class PlayerBattler : MonoBehaviour
{
    [SerializeField] private Text _healthOnScreen;
    [SerializeField, Min(1)] private float _damage;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private LayerMask _layerMaskEnemy;
    [SerializeField] private float _radiusAttack;
    [SerializeField] private float _attackCoolDown;

    private bool _isAttack = false;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _isAttack == false)
        {
            Attack();
            Debug.Log("Я наношу удар"); 
        }
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPosition.position, _radiusAttack, _layerMaskEnemy);
        _isAttack = true;

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<HealthSystem>().TakeDamage(_damage);
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
