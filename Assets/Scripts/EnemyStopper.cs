using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopper : FakeGravityBody
{
    public float duration;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            StopEnemies();
            Destroy(gameObject);
        }
    }

    public void StopEnemies()
    {
        EnemyEntity[] enemies = FindObjectsOfType<EnemyEntity>();

        if (enemies.Length > 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                    enemies[i].FreezeEnemy(duration);
            }
        }
    }
}
