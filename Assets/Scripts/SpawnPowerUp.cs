using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPowerUp : BaseSpawner
{
    public bool isSpawned = false;
    public bool isActived;
    public AudioSource audioSource;
    private UIManager uiManager;

    protected override void Start()
    {
        base.Start();
        currentSpawnTime = spawnTime;
        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
    }

    protected override void Update()
    {
        if(!isSpawned && !isActived)
        {
            currentSpawnTime -= Time.deltaTime;
            uiManager.UpdateTimePowerUpLeft((int)currentSpawnTime);
        }
        if (currentSpawnTime <= 0)
        {
            isSpawned = true;
            uiManager.powerUpTimeLeftText.enabled = false;
            uiManager.powerUpSpawned.enabled = true;
            SpawnPU();
        }
    }

    private void SpawnPU()
    {
        Vector3 position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);
        Instantiate(objectToSpawn, position, new Quaternion(0, Random.value, 0, 0));
        audioSource.Play();
        currentSpawnTime = spawnTime;
    }
}
