using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Global")]
    [SerializeField] private LayerCheckComponent _groundCheckLayer;

    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector3 _previousPosition;

    private static readonly int IsRunningKey = Animator.StringToHash("isRunning");
    private static readonly int IsJumpingKey = Animator.StringToHash("isJumping");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _previousPosition = transform.position;
    }

    private void Update()
    {
        _isGrounded = IsGrounded();

        var horizontalInput = Mathf.Abs((transform.position.x - _previousPosition.x) / Time.deltaTime);
        if (horizontalInput > 0 && _isGrounded) {
            _animator.SetBool(IsRunningKey, true);
        }
        else {
            _animator.SetBool(IsRunningKey, false);
        }

        _previousPosition = transform.position;
        _animator.SetBool(IsJumpingKey, !_isGrounded);
    }

    public void Move(float direction)
    {
        if (direction != 0)
        {
            var xPos = transform.position.x + _speed * direction * Time.deltaTime;
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(direction, 1, 1);
            return;
        } 
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

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
