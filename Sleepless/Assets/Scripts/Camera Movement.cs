using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    void Start()
    {
        _playerTransform = Locator.Instance._player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 target = new Vector3(_playerTransform.position.x + _xOffset, _playerTransform.position.y + _yOffset, -10);

        transform.position = Vector3.Lerp(transform.position, target, _followSpeed * Time.deltaTime);
    }
}
