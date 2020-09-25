using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPowerUp : MonoBehaviour
{
    [Range(min: 0, max: 30)]
    public float timeToSpawn;
    public float currentTimeToSpawn;
    public GameObject powerUp;
    private SphereCollider sphereCollider;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        currentTimeToSpawn = timeToSpawn;
    }

    void Update()
    {
        currentTimeToSpawn -= Time.deltaTime;
        if (currentTimeToSpawn <= 0)
            SpawnPU();
    }

    private void SpawnPU()
    {
        Vector3 position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);
        Instantiate(powerUp, position, new Quaternion(0, Random.value, 0, 0));
        currentTimeToSpawn = timeToSpawn;
    }
}
