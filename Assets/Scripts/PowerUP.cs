using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : FakeGravityBody
{
    public Animator animator;
    private SpawnPowerUp powerUp;
    private UIManager uiManager;

    public override void Start()
    {
        base.Start();
        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
        powerUp = GameObject.Find("Planet").GetComponent<SpawnPowerUp>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            PlayerEntity player = collision.gameObject.GetComponent<PlayerEntity>();
            player.ActiveInvulnerability();
            powerUp.isSpawned = false;
            powerUp.isActived = true;
            uiManager.powerUpSpawned.enabled = false;
            uiManager.powerUpActived.enabled = true;
            Destroy(gameObject);
        }
    }
}