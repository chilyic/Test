using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 17;
    [SerializeField] private float _jump = 2.5f;
    [SerializeField] private float _rotSpeed = 250;
    [SerializeField] private float _gravity = 8;

    private Camera _mainCamera;
    private Animator _animator;
    private CharacterController _controller;
    private Vector3 _moveVector;
    private Vector3 _camForward;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;
    }
        
    void Update()
    {
        Move();
        Gravity();
        Rotate();
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");

        _camForward = _mainCamera.transform.forward;
        _camForward.y = 0;
        _moveVector = Quaternion.LookRotation(_camForward) * _moveVector;

        _controller.Move(_moveVector * _speed * Time.deltaTime);

        if (_moveVector.x == 0 && _moveVector.z == 0)
            _animator.SetFloat("Move", 0);
        else
            _animator.SetFloat("Move", _moveVector.magnitude);
    }

    private void Gravity()
    {
        _moveVector.y = _controller.isGrounded ? 0 : _moveVector.y - _gravity * Time.deltaTime;

        if (_controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            _moveVector.y += _jump;
            _animator.SetTrigger("Jump");
        }        
    }

    private void Rotate()
    {
        _moveVector = transform.InverseTransformDirection(_moveVector);
        float turnAmount = Mathf.Atan2(_moveVector.x, _moveVector.z);
        transform.Rotate(0, turnAmount * _rotSpeed * Time.deltaTime, 0);
    }
}
