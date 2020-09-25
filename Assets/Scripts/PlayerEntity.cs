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
    public float timeInv;
    private float currentTimeInv;

    private void KillPlayer()
    {
        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.WinLoseGame(false);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
            KillPlayer();
    }

    public void ActiveInvulnerability()
    {
        sphere.SetActive(true);
        currentTimeInv = timeInv;
        currentTimeInv -= Time.deltaTime;

        if (currentTimeInv <= 0)
        {
            DesactiveInvulnerability();
        }
    }

    public void DesactiveInvulnerability()
    {
        sphere.SetActive(false);
    }
}
