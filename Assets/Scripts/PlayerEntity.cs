using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : FakeGravityBody
{
    [Header("Player Settings")]
    public float movementSpeed = 6;
    public float rotationSpeed = 6;
    public float fireRate = 10;
    [Header("Shot Settings")]
    public GameObject shotPrefab;
    public Transform spawnPosition;
    [Header("PowerUp")]
    public GameObject sphere;
    [Header("Audio Settings")]    
    public AudioClip[] sounds;

    [HideInInspector]
    public AudioSource audioSource;
    private SpawnPowerUp powerUp;
    private UIManager uiManager;

    public override void Start()
    {
        base.Start();
        powerUp = GameObject.Find("Planet").GetComponent<SpawnPowerUp>();
        audioSource = GetComponent<AudioSource>();
        uiManager = GetComponent<UIManager>();
    }

    private void KillPlayer()
    {
        CreateDeathEffect();

        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.WinLoseGame(false);

        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
            KillPlayer();
    }

    public void ActiveInvulnerability()
    {
        SetAudioClip(sounds[1]);
        audioSource.Play();
        sphere.SetActive(true);
    }

    public void DesactiveInvulnerability()
    {
        SetAudioClip(sounds[2]);
        audioSource.Play();
        sphere.SetActive(false);
        uiManager.powerUpActived.enabled = false;
        uiManager.powerUpTimeLeftText.enabled = true;
        powerUp.isActived = false;
    }

    public void SetAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
    }
}
