using UnityEngine;

public class EnemyPartol : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _patrollingPoints;

    private int _currentPoint;
    private float _inaccuracyPosition = 0.6f;
    private DetectorPlayer _detectorPlayer;
    private EnemyPursuit _enemyPursuit;
    private FlipObjectRotation _flipObjectRotation;
    private bool _isPartol = true;

    private void Start()
    {
        _detectorPlayer = GetComponent<DetectorPlayer>();
        _enemyPursuit = GetComponent<EnemyPursuit>();
        _flipObjectRotation = GetComponent<FlipObjectRotation>();
    }

    private void Update()
    {
        if ((transform.position - _detectorPlayer.Detection().position).sqrMagnitude < _enemyPursuit.PursuitDistance)
        {
            _isPartol = false;
            _enemyPursuit.PursuitChangeStatus(true);
        }

        if ((transform.position - _detectorPlayer.Detection().position).sqrMagnitude > _enemyPursuit.PursuitDistance)
        {
            _enemyPursuit.PursuitChangeStatus(false);
            _isPartol = true;
        }
    }

    private void FixedUpdate()
    {    
        if (_isPartol == true)
        {
            Patrol();
        }
        else if (_enemyPursuit.IsPursuit == true)
        {
            _enemyPursuit.Pursuit();
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
