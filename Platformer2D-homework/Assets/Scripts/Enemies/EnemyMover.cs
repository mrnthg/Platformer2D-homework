using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _patrollimgPoints;

    private int _currentPoint;
    private float _inaccuracyPosition = 0.6f;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _patrollimgPoints[_currentPoint].position) <= _inaccuracyPosition)
        {
            _currentPoint = (_currentPoint + 1) % _patrollimgPoints.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, _patrollimgPoints[_currentPoint].position, _moveSpeed * Time.deltaTime);
        
        FlipEnemy();
    }

    private void FlipEnemy()
    {
        if (transform.position.x > _patrollimgPoints[_currentPoint].position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x < _patrollimgPoints[_currentPoint].position.x)
        {
            transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
