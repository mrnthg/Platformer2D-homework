using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(InspectorHardSurface))]
public class PlayerMover : MonoBehaviour
{
    private readonly string _horizontalMovement = "Horizontal";
    private readonly string _space = "space";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Animator _playerAnimation;
    private Rigidbody2D _playerRigidbody;
    private InspectorHardSurface _checkHardSurface;
    private float horizontalImput = 0f;
    private bool _isJump = false;

    private void Start()
    {
        _playerAnimation = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _checkHardSurface = GetComponent<InspectorHardSurface>();
    }

    private void Update()
    {
        horizontalImput = Input.GetAxis(_horizontalMovement);

        if (Input.GetKeyDown(_space) && _checkHardSurface.IsHardSurface)
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {        
        _playerAnimation.SetFloat(PlayerAnimatorData.Parameters.Speed, Mathf.Abs(horizontalImput));

        FlipPlayerRotation(horizontalImput);

        _playerRigidbody.velocity = new Vector2(horizontalImput * _moveSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_isJump)
        {         
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
            _isJump = false;
        }
    }

    private void FlipPlayerRotation(float value)
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
