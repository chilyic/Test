using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _source;
 
    void Start()
    {
        _source = GetComponent<AudioSource>();
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        int track = Random.Range(0, _clips.Length);
        _source.clip = _clips[track];
        _source.Play();
        yield return new WaitForSeconds(_clips[track].length);

        StartCoroutine(Play());
    }
}
