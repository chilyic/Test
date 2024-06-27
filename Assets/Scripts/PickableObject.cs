using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private ParticleSystem _particle;
    private MeshRenderer _mesh;
    private float _delay;
    
    void Start()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
            Destroy(gameObject);

        _particle = GetComponentInChildren<ParticleSystem>();
        _mesh = GetComponent<MeshRenderer>();
        _delay = _particle.main.startLifetimeMultiplier;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _particle.Play();
            _mesh.enabled = false;
            PlayerPrefs.SetString(gameObject.name, "");
            Destroy(gameObject, _delay);
        }
    }
}
