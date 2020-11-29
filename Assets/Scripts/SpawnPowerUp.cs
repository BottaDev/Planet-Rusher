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

    protected override void Start()
    {
        base.Start();
        currentSpawnTime = spawnTime;
    }

    protected override void Update()
    {
        if(!isSpawned && !isActived)
            currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            isSpawned = true;
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
