using UnityEngine;

public class EnemyPartol : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _patrollingPoints;
    [SerializeField] private float _pursuitDistance;

    private int _currentPoint;
    private float _inaccuracyPosition = 0.6f;
    private Transform _player;
    private bool _isPartol = true;
    private bool _isPursuit = false;

    public bool IsPursuit => _isPursuit;

    private void Start()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerMover>().GetComponent<Transform>();         
        }               
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) < _pursuitDistance)
        {
            _isPartol = false;
            _isPursuit = true;
        }

        if (Vector2.Distance(transform.position, _player.position) > _pursuitDistance)
        {
            _isPursuit = false;
            _isPartol = true;
        }
    }

    private void FixedUpdate()
    {    
        if (_isPartol == true)
        {
            Patrol();
        }
        else if (_isPursuit == true)
        {
            Pursuit();
        }
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, _patrollingPoints[_currentPoint].position) <= _inaccuracyPosition)
        {
            _currentPoint = (++_currentPoint) % _patrollingPoints.Length;            
        }

        Flip(_patrollingPoints[_currentPoint]);
        transform.position = Vector2.MoveTowards(transform.position, _patrollingPoints[_currentPoint].position, _moveSpeed * Time.deltaTime); 
    }

    private void Pursuit()
    {       
        Flip(_player);
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
    }

    private void Flip(Transform target)
    {
        if (transform.position.x > target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.x < target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);        
        }        
    }
}
