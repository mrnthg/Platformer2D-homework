using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private readonly string HorizontalMovement = "Horizontal";
    private readonly string Space = "space";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Animator _playerAnimation;
    private Rigidbody2D _playerRigidbody;
    private CheckHardSurface _checkHardSurface;

    private void Start()
    {
        _playerAnimation = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _checkHardSurface = GetComponent<CheckHardSurface>();
    }

    private void Update()
    {        
        Move();
        Jump();
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
        if (Input.GetKeyDown(Space) && _checkHardSurface.IsHardSurface)
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
