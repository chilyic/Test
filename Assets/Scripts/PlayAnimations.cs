using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float hor = Mathf.Abs(Input.GetAxis("Horizontal"));
        float ver = Mathf.Abs(Input.GetAxis("Vertical"));

        if (hor > ver)
            _animator.SetFloat("Blend", hor);
        else if (hor < ver)
            _animator.SetFloat("Blend",ver);
        else if (hor == 0 && ver == 0)
            _animator.SetFloat("Blend", 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
        }
    }
}
