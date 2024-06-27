using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private float _gravity;
    [SerializeField] private float _rotSpeed;

    private Shooting _shooting;
    private Camera _camera;
    private CharacterController _controller;
    private Vector3 _moveVector;
    private Vector3 _camForward;
    private float _rotY;
    private int _pickableObj = 0;

    void Start()
    {
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();
        _shooting = GetComponentInChildren<Shooting>();
    }
    
    void Update()
    {
        Move();
        Jump();

        if (Input.GetMouseButtonDown(0))
        {
            _shooting.Shoot(15);
        }
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");

        _camForward = _camera.transform.forward;
        _camForward.y = 0;
        _moveVector = Quaternion.LookRotation(_camForward) * _moveVector;

        _rotY += _rotSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, _rotY, 0);

        _controller.Move(_moveVector * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        _moveVector.y = _controller.isGrounded ? 0 : _moveVector.y -= _gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            _moveVector.y += _jump;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PickableObj"))
        {
            _pickableObj++;
            _text.text = _pickableObj.ToString();
        }
    }
}
