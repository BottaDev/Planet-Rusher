using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public float spawnTime;
    public float radius = 5f;
    public GameObject meteorPrefab;

    private float currentSpawnTime = 2f;
    

    private void Update()
    {
        if (currentSpawnTime <= 0)
            SpawnMeteor();
        else
            currentSpawnTime -= Time.deltaTime;
    }

    private void SpawnMeteor() 
    {
        Vector3 position = new Vector3(Random.insideUnitSphere.x * radius, Random.insideUnitSphere.y * radius, Random.insideUnitSphere.z * radius);
        Instantiate(meteorPrefab, position, Quaternion.identity);

        currentSpawnTime = spawnTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
