using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //basic movement
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _backSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private bool _isGrounded;


    //fancy jump shit

    //variable jump height

    [SerializeField]private float _jumpCutMultiplier;
    [SerializeField]private float _maxJumpHoldTime;
    private bool _isJumping;
    private bool _jumpHeld;
    private float _jumpTimer = 0f;

    void Start()
    {
        _rb = Locator.Instance._player.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(1, 0, 0) * _minSpeed * Time.deltaTime;

        Movement();
        Jump();
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
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _isGrounded = false;
            _jumpTimer = 0f;
            _isJumping = true;
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
    private  void JumpTimer()
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
}
