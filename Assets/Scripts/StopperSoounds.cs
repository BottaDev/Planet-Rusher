using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperSoounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void Awake()
    {
        audioSource.Play();
    }

    public void DesactivedPowerUp()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
    }
}
