using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Range(min: 0, max:3f)]
    public float spawnTime;
    public float radius = 5f;
    public GameObject meteorPrefab;

    private float currentSpawnTime = 3f;    

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
