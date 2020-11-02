using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterEntity : EnemyEntity
{
    public float fireRate = 3f;
    public GameObject shotPrefab;
    public Transform[] spawnPosition;

    protected float currentFireRate = 1f;

    protected override void Update()
    {
        base.Update();

        if (currentFireRate <= 0)
            Shot();
        else
            currentFireRate -= Time.deltaTime;
    }

    protected virtual void Shot()
    {
        Instantiate(shotPrefab, spawnPosition[0].position, spawnPosition[0].rotation);

        currentFireRate = fireRate;
    }
}
