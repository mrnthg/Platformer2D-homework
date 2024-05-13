using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Animator _playerAnimation;
    private Rigidbody2D _playerRigidbody;
    private float _jumpGravity = -22f;
    private float _realGravity = -9.8f;
    private bool _isJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            Debug.Log("Diamond");
        }
    }

    private void Start()
    {
        _playerAnimation = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    public void StartJump()
    {
        _isJump = true;
        _playerAnimation.SetBool("isJump", true);
        Physics2D.gravity = new Vector2(0, _jumpGravity);
    }

    public void StopJump()
    {
        _isJump = false;
        _playerAnimation.SetBool("isJump", false);
        Physics2D.gravity = new Vector2(0, _realGravity);
    }

    private void Move()
    {
        float horizontalImput = Input.GetAxis("Horizontal");
        _playerAnimation.SetFloat("Speed", Mathf.Abs(horizontalImput));

        FlipPlayer(horizontalImput);

        _playerRigidbody.velocity = new Vector2(horizontalImput * _moveSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space") && !_isJump)
        {           
            _playerRigidbody.AddForce(new Vector2(_playerRigidbody.velocity.x, _jumpForce), ForceMode2D.Impulse);         
        }      
    }

    private void FlipPlayer(float value)
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
