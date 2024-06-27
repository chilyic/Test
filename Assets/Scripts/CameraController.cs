using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _minX = 5;
    [SerializeField] private float _maxX = 75;    
    [SerializeField] private float _rotSpeed = 5;
    [SerializeField] private float _distance = 6;

    private float _rotX = 45;
    private float _rotY = 0;
    
    void LateUpdate()
    {
        _rotX -= _rotSpeed * Input.GetAxis("Mouse Y");
        _rotY += _rotSpeed * Input.GetAxis("Mouse X");
        _rotX = Mathf.Clamp(_rotX, _minX, _maxX);

        transform.localEulerAngles = new Vector3(_rotX, _rotY, 0);

        transform.position = _target.position - transform.forward * _distance;
    }
}
