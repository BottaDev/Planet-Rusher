using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexEnemyShooterEntity : EnemyShooterEntity
{
    public float timeIdle = 2f;

    protected override void Shot()
    {
        audioSource.Play();

        StartCoroutine(ShotIdle());

        currentFireRate = fireRate;
    }

    private IEnumerator ShotIdle()
    {
        float baseSpeed = speed;
        speed = 0f;

        yield return new WaitForSeconds(timeIdle / 2);

        Instantiate(shotPrefab, spawnPosition[0].position, spawnPosition[0].rotation);
        Instantiate(shotPrefab, spawnPosition[1].position, spawnPosition[1].rotation);
        Instantiate(shotPrefab, spawnPosition[2].position, spawnPosition[2].rotation);
        Instantiate(shotPrefab, spawnPosition[3].position, spawnPosition[3].rotation);

        yield return new WaitForSeconds(timeIdle / 2);

        speed = baseSpeed;
    }
}
