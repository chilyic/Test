using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _distance;
    [SerializeField] private Transform[] _points;

    private int _currentPoint;
    private bool _isInAttack;

    public float Damage => _damage;
    public Transform Player { get => _player; set => _player = value; }

    public void Start()
    {
        transform.position = _points[0].position;
        _currentPoint = Random.Range(1, _points.Length);
        _isInAttack = false;
    }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_isInAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);
            transform.LookAt(_points[_currentPoint]);
            if (Vector3.Distance(transform.position, _points[_currentPoint].position) < 1)
            {
                _currentPoint = Random.Range(0, _points.Length);
            }
        }

        if (_player != null)
        {
            if (Vector3.Distance(transform.position, _player.position) < _distance)
            {
                _isInAttack = true;
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
                transform.LookAt(_player);
                Attack();
            }
            else
                _isInAttack = false;
        }
    }

    public virtual void Attack()
    {

    }
}