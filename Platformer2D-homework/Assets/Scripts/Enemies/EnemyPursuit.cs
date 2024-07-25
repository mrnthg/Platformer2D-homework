using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuit : MonoBehaviour
{
    [SerializeField] private float _moveSpeedPursuit;

    private DetectorPlayer _detectorPlayer;
    private FlipObjectRotation _flipObjectRotation;
    private bool _isPursuit = false;

    public bool IsPursuit => _isPursuit;

    private void Start()
    {
        _detectorPlayer = GetComponent<DetectorPlayer>();
        _flipObjectRotation = GetComponent<FlipObjectRotation>();
    }

    private void FixedUpdate()
    {
        if (_isPursuit)
        {
            Pursuit();
        }
    }

    public void Pursuit()
    {
        _flipObjectRotation.Flip(_detectorPlayer.Detection());
        transform.position = Vector2.MoveTowards(transform.position, _detectorPlayer.Detection().position, _moveSpeedPursuit * Time.deltaTime);
    }

    public void PursuitStatusTrue()
    {
        _isPursuit = true;
    }

    public void PursuitStatusFalse()
    {
        _isPursuit = false;
    }
}
