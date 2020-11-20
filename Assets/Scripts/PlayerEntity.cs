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
    private SpawnPowerUp powerUp;

    public override void Start()
    {
        base.Start();
        powerUp = GameObject.Find("Planet").GetComponent<SpawnPowerUp>();
    }

    private void KillPlayer()
    {
        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.WinLoseGame(false);

        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
            KillPlayer();
    }

    public void ActiveInvulnerability()
    {
        sphere.SetActive(true);
    }

    public void DesactiveInvulnerability()
    {
        sphere.SetActive(false);
        powerUp.isActived = false;
    }
}
