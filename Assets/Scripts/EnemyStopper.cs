using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopper : FakeGravityBody
{
    public float duration;
    public Animator animator;
    public GameObject stopperSounds;
    private StopperSoounds stopper;
    private SpawnPowerUp powerUp;
    private UIManager uiManager;

    public override void Awake()
    {
        base.Awake();

        //stopper = GameObject.Find("Stopper Sounds").GetComponent<StopperSoounds>();
        powerUp = GameObject.Find("Planet").GetComponent<SpawnPowerUp>();
        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            uiManager.powerUpSpawned.enabled = false;
            uiManager.powerUpActived.enabled = true;
            powerUp.isActived = true;

            GameObject soundObj = Instantiate(stopperSounds, transform.position, transform.rotation);

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
