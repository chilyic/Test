using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    [SerializeField] private float _fireRate = 1;

    private Shooting _shooting;
    private bool _canShoot;

    new void Start()
    {
        base.Start();
        _shooting = GetComponentInChildren<Shooting>();
        _canShoot = true;
    }

    new void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        if (_canShoot)
            StartCoroutine(Shot());  
    }

    private IEnumerator Shot()
    {
        _canShoot = false;
        _shooting.Shoot(Damage);
        yield return new WaitForSeconds(_fireRate);
        _canShoot = true;
    }
}
