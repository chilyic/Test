using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private bool _isPlayer;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangeHealth(float value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0)
        {
            if (!_isPlayer)
                Destroy(gameObject);
            else
            {
                //GetComponent<Movement>().Dead();                
            }
        }

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
