using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private float _backSpeed;
    // Start is called before the first frame update

    void Start()
    {
        _backSpeed = _minSpeed + _speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(1, 0, 0) * _minSpeed * Time.deltaTime;

        Movement();
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
}
