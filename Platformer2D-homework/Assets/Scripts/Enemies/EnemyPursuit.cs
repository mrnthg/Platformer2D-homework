using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPursuit : MonoBehaviour
{
    [SerializeField] private float _moveSpeedPursuit;
    [SerializeField] private float _pursuitDistance;

    private DetectorPlayer _detectorPlayer;
    private FlipObjectRotation _flipObjectRotation;
    private bool _isPursuit = false;

    public bool IsPursuit => _isPursuit;
    public float PursuitDistance => _pursuitDistance;

    private void Start()
    {
        _detectorPlayer = GetComponent<DetectorPlayer>();
        _flipObjectRotation = GetComponent<FlipObjectRotation>();
    }

    public void Pursuit()
    {
        _flipObjectRotation.Flip(_detectorPlayer.Detection());
        transform.position = Vector2.MoveTowards(transform.position, _detectorPlayer.Detection().position, _moveSpeedPursuit * Time.deltaTime);
    }

    public void PursuitChangeStatus(bool isPursuit)
    {
        _isPursuit = isPursuit;
    }
}
