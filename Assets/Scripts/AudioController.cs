using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coin;
    [SerializeField]
    private AudioClip _blowUp;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Coin")
        {
            _audio.PlayOneShot(_coin);
        }
        if (triggerCollider.tag == "Asteroid")
        {
            _audio.PlayOneShot(_blowUp);
        }
    }

}
