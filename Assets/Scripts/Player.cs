using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] private LayerCheckComponent _groundCheckLayer;

    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isRunning;
    private bool _isGrounded;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private static readonly int IsRunningKey = Animator.StringToHash("isRunning");
    private static readonly int IsJumpingKey = Animator.StringToHash("isJumping");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isGrounded = IsGrounded();

        _animator.SetBool(IsRunningKey, _isRunning);
        _animator.SetBool(IsJumpingKey, !_isGrounded);
    }

    public void Move(float direction)
    {
        _isRunning = true;

        var xPos = transform.position.x + _speed * direction * Time.deltaTime;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        transform.localScale = new Vector3(direction, 1, 1);
    }

    public void Idle()
    {
        _isRunning = false;
    }

    public void Jump(bool jump)
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private bool IsGrounded()
    {
        return _groundCheckLayer.IsTouchinLayer;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
