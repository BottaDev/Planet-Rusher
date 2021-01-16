﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    public string SpawnerName = "";
    public float spawnTime;
    public GameObject objectToSpawn;
    public float radius = 0f;
    public bool useSphereRadius = false;

    [SerializeField]
    protected float currentSpawnTime = 3f;
    protected SphereCollider sphereCollider;

    public Vector3 center;
    public Vector3 size;

    protected virtual void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    protected virtual void Update()
    {
        if (currentSpawnTime <= 0)
            SpawnObject();
        else
            currentSpawnTime -= Time.deltaTime;
    }

    protected virtual void SpawnObject()
    {
        Vector3 position;

        bool canSpawn = false;

        while (!canSpawn)
        {
            if (useSphereRadius)
                position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);
            else
                position = new Vector3(Random.insideUnitSphere.x * radius, Random.insideUnitSphere.y * radius, Random.insideUnitSphere.z * radius);

            Instantiate(objectToSpawn, position, new Quaternion(0, Random.value, 0, 0));

            GameObject tempObj = new GameObject("temporary cube with collider (SpawnLocationValid)");
            tempObj.transform.position = position;
            var bCol = tempObj.AddComponent<SphereCollider>();
            bCol.isTrigger = true;
            bCol.radius = 1.5f;

            Collider[] colls = Physics.OverlapSphere(position, bCol.radius, 10);

            if (colls.Length == 0)
            {
                print("lo hizo");
                GameObject.Destroy(bCol);
                canSpawn = true;
            }
            else
            {
                print("no spawneo");
                canSpawn = false;
                GameObject.Destroy(bCol);
            }
        }

        currentSpawnTime = spawnTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if(!useSphereRadius)
            Gizmos.DrawWireSphere(transform.position, radius);
    }
}
