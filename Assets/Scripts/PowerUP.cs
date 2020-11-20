using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : FakeGravityBody
{
    public Animator animator;
    private SpawnPowerUp powerUp;

    public override void Start()
    {
        base.Start();
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
            Destroy(gameObject);
        }
    }
}
