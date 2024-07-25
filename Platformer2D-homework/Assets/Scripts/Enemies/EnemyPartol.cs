using System;
using UnityEngine;

public class EnemyPartol : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _patrollingPoints;
    [SerializeField] private float _detectedDistance;

    private int _currentPoint;
    private float _inaccuracyPosition = 0.6f;
    private DetectorPlayer _detectorPlayer;
    private Transform _playerPosition;
    private EnemyPursuit _enemyPursuit;
    private FlipObjectRotation _flipObjectRotation;
    private bool _isPartol = true;

    public event Action OnPatrol;

    private void Start()
    {
        _detectorPlayer = GetComponent<DetectorPlayer>();
        _enemyPursuit = GetComponent<EnemyPursuit>();
        _flipObjectRotation = GetComponent<FlipObjectRotation>(); 

         _playerPosition = _detectorPlayer.Detection();
    }

    private void Update()
    {
        _detectorPlayer.Detection(); 

        if (_detectorPlayer.IsDetected)
        {
            _isPartol = false;
            _enemyPursuit.PursuitStatusTrue();
        }
        else
        {
            _enemyPursuit.PursuitStatusFalse();
            _isPartol = true;
        }
    }

    private void FixedUpdate()
    {    
        if (_isPartol)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if ((transform.position - _patrollingPoints[_currentPoint].position).sqrMagnitude <= _inaccuracyPosition)
        {
            _currentPoint = (++_currentPoint) % _patrollingPoints.Length;            
        }

        _flipObjectRotation.Flip(_patrollingPoints[_currentPoint]);
        transform.position = Vector2.MoveTowards(transform.position, _patrollingPoints[_currentPoint].position, _moveSpeed * Time.deltaTime); 
    }
}
