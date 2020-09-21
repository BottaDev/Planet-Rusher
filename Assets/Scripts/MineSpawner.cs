using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MineSpawner : MonoBehaviour
{
    [Range(min: 0, max: 20f)]
    public float spawnTime;
    public GameObject minePrefab;

    private SphereCollider sphereCollider;
    private float currentSpawnTime = 3f;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (currentSpawnTime <= 0)
            SpawnMine();
        else
            currentSpawnTime -= Time.deltaTime;
    }

    private void SpawnMine()
    {
        Vector3 position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);
        Instantiate(minePrefab, position, new Quaternion(0, Random.value, 0, 0));

        currentSpawnTime = spawnTime;
    }
}
