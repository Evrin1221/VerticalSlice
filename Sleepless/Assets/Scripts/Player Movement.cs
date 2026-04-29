using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //basic movement
    // [SerializeField] private float _minSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _backSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private bool _isGrounded;


    //fancy jump shit

    //variable jump height

    [SerializeField] private float _jumpCutMultiplier;
    [SerializeField] private float _maxJumpHoldTime;
    private bool _isJumping;
    private bool _jumpHeld;
    private float _jumpTimer = 0f;


    //coyote time

    private float _coyoteTimer = 0f;
    private float _coyoteTimeMax = 1.2f;
    private bool _canStillJump;


    //jump buffer

    private float _jumpBufferTimer = 0f;
    private float _jumpBufferMax = 0.1f;
    private bool _storingJump;


    //fall multiplier

    private bool __isFalling;
    [SerializeField] private float _fallMultiplier;

    //Animations
    private Animator _animator;

    void Start()
    {
        _rb = Locator.Instance._player.gameObject.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position + new Vector3(1, 0, 0) * _minSpeed * Time.deltaTime;
        DetectIfFalling();
        Movement();
        CoyoteTime();
        JumpBuffer();
        Jump();
        ApplyFallMultiplier();
        AnimatorGroundedCheck();
      

    }


    private void Movement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * _backSpeed * Time.deltaTime;
        }


    }

    private void Jump()
    {
        if ( (_isGrounded || _canStillJump) && _storingJump)
        {
            _coyoteTimer = 0f;
            _canStillJump = false;

            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _isGrounded = false;
            _jumpTimer = 0f;
            _isJumping = true;
            _storingJump = false;
            _jumpBufferTimer = 0f;

        }

        if (Input.GetKey(KeyCode.Space) && _isJumping)
        {
            JumpTimer();
        }

        if ((_jumpTimer >= _maxJumpHoldTime || Input.GetKeyUp(KeyCode.Space)) && _isJumping)
        {
            _isJumping = false;
            _jumpTimer = 0f;

            if (_rb.velocity.y > 0f)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * _jumpCutMultiplier);
            }
        }
    }
    private void JumpTimer()
    {
        _jumpTimer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void CoyoteTime()
    {
        if (_isGrounded)
        {
            _coyoteTimer = _coyoteTimeMax;
            _canStillJump = true;
        }
        else if (!_isGrounded)
        {

            _coyoteTimer -= Time.deltaTime;
            if (_coyoteTimer <= 0)
            {
                _canStillJump = false;
            }
        }
    }

    private void JumpBuffer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpBufferTimer = _jumpBufferMax;
            _storingJump = true;

        }
        if (_storingJump)
        {
            JumpBufferTimer();
            if (_jumpBufferTimer <= 0)
            {
                _storingJump = false;
                _jumpBufferTimer = 0f;
            }
        }


    }

    private void JumpBufferTimer()
    {
        _jumpBufferTimer -= Time.deltaTime;
    }

    private void DetectIfFalling()
    {
        if(_rb.velocity.y < 0f)
        {
            __isFalling = true;
        }
        else
        {
            __isFalling = false;
        }
    }

    private void ApplyFallMultiplier()
    {
        if (__isFalling)
        {
            _rb.gravityScale = _fallMultiplier;
        }
    }

    private void AnimatorGroundedCheck()
    {
        _animator.SetBool("isGrounded", _isGrounded);
    }
}


