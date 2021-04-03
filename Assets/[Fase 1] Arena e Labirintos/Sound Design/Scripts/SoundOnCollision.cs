using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource),typeof(Collider))]
public class SoundOnCollision : MonoBehaviour
{
    [SerializeField]
    bool playJustOnce;
    AudioSource audioSource;
    bool isPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playJustOnce && !isPlayed)
        {
            audioSource.Play();
            isPlayed = true;
        }

        if(!playJustOnce)
        {
            audioSource.Play();
        }
    }

}
