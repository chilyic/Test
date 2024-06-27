using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _minX = -60;
    [SerializeField] private float _maxX = 60;

    private float _rotX;

    void LateUpdate()
    {
        _rotX -= Input.GetAxis("Mouse Y") * _rotSpeed;
        _rotX = Mathf.Clamp(_rotX, _minX, _maxX);

        transform.localEulerAngles = new Vector3(_rotX, 0, 0);
    }
}
