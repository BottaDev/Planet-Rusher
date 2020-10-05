using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterEntity : EnemyEntity
{
    public float fireRate = 3f;
    public GameObject shotPrefab;
    public Transform spawnPosition;

    private float currentFireRate = 1f;

    protected override void Update()
    {
        base.Update();

        if (currentFireRate <= 0)
            Shot();
        else
            currentFireRate -= Time.deltaTime;
    }

    private void Shot()
    {
        Instantiate(shotPrefab, spawnPosition.position, spawnPosition.rotation);

        currentFireRate = fireRate;
    }
}
