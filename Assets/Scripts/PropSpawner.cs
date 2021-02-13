using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public string spawnerName = "";
    public float distanceFromPlayer = 8f;       // Distance to spawn the object from the player
    public int propsToSpawn = 1;
    public GameObject[] props;

    private Transform playerPos;
    private SphereCollider sphereCollider;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        for (int i = 0; i < propsToSpawn; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Vector3 position;

        bool canSpawn = false;

        while (!canSpawn)
        {
            position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);

            GameObject tempObj = new GameObject("Temporary collider");
            tempObj.transform.position = position;
            var bCol = tempObj.AddComponent<SphereCollider>();
            bCol.isTrigger = true;
            bCol.radius = 3f;

            // We create this object to prevent props from spawning near the player
            GameObject tempPlayerCol = new GameObject("Temporary player collider");
            tempObj.transform.position = playerPos.position;
            var pCol = tempObj.AddComponent<SphereCollider>();
            pCol.isTrigger = true;
            pCol.radius = distanceFromPlayer;

            Collider[] colls = Physics.OverlapSphere(position, bCol.radius, 10);

            if (colls.Length == 0)
            {
                Destroy(tempObj);
                Destroy(tempPlayerCol);

                Instantiate(props[Random.Range(0, props.Length)], position, new Quaternion(0, Random.Range(0, 361), 0, 0));

                canSpawn = true;
            }
            else
            {
                Destroy(tempObj);
                Destroy(tempPlayerCol);

                canSpawn = false;
            }
        }
    }
}
