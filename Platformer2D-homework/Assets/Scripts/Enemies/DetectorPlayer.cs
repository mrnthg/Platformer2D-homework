using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    [SerializeField] private float _detectedHorizontalDistance;
    [SerializeField] private float _detectedVerticalDistance;
    [SerializeField] private LayerMask _layerMaskPlayer;

    private Transform _playerPosition;
    private Vector2 _detectedArea;
    private float _detectedAreaAngle = 0;
    private bool _isDetected = false;

    public bool IsDetected => _isDetected;

    private void Start()
    {
        _detectedArea = new Vector2(_detectedHorizontalDistance, _detectedVerticalDistance);
    }

    public Transform Detection()
    {
        Collider2D player = Physics2D.OverlapBox(transform.position, _detectedArea, _detectedAreaAngle, _layerMaskPlayer);

        if (player != null)
        {
            _isDetected = true;
            _playerPosition = player.transform;
        }
        else
        {
            _isDetected = false;
        }

        return _playerPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _detectedArea);
    }
}
