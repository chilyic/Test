using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audios;

    private AudioSource _source;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        int index = Random.Range(0, _audios.Length);
        _source.clip = _audios[index];
        _source.Play();
        yield return new WaitForSeconds(_audios[index].length);

        StartCoroutine(Play());
    }
}
