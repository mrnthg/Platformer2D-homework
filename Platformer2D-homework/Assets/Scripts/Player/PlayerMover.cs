using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private readonly string HorizontalMovement = "Horizontal";
    private readonly string Space = "space";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private RaycastHit2D _hit;
    private string _layerMask = "HardSurface";
    private Animator _playerAnimation;
    private Rigidbody2D _playerRigidbody;
    private bool _isHardSurface;
    private float _rayDistance = 0.85f;
  
    private void Start()
    {
        _playerAnimation = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {        
        Move();
        Jump();
        GroundCheck();
    }

    private void GroundCheck()
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

    private void Move()
    {
        float horizontalImput = Input.GetAxis(HorizontalMovement);
        _playerAnimation.SetFloat(PlayerAnimatorData.Parameters.Speed, Mathf.Abs(horizontalImput));

        Flip(horizontalImput);

        _playerRigidbody.velocity = new Vector2(horizontalImput * _moveSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(Space) && _isHardSurface)
        {         
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
        }
    }

    private void Flip(float value)
    {
        if (value > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (value < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
