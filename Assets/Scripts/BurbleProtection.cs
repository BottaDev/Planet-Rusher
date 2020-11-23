using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbleProtection : MonoBehaviour
{
    private PlayerEntity player;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = gameObject.GetComponentInParent<PlayerEntity>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject);
            audioSource.Play();
            player.DesactiveInvulnerability();
        }
    }
}
