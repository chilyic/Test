using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    
    public void Shoot(float damage)
    {
        GameObject bullet = Instantiate(_bullet, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().Damage = damage;
    }
}
