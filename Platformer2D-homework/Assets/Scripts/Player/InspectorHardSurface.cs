using UnityEngine;

public class InspectorHardSurface : MonoBehaviour
{
    private RaycastHit2D _hit;
    private string _layerMask = "HardSurface";
    private Animator _playerAnimation;
    private bool _isHardSurface = true;
    private float _rayDistance = 0.85f;

    public bool IsHardSurface => _isHardSurface;

    private void Start()
    {
        _playerAnimation = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SurfaceChecker();
    }

    private void SurfaceChecker()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, LayerMask.GetMask(_layerMask));

        if (_hit.collider != null)
        {
            _isHardSurface = true;
            _playerAnimation.SetBool(PlayerAnimatorData.Parameters.IsJump, false);
        }
        else
        {
            _isHardSurface = false;
            _playerAnimation.SetBool(PlayerAnimatorData.Parameters.IsJump, true);
        }
        
        Debug.DrawRay(transform.position, Vector2.down * _rayDistance, Color.red); 
    }
}
