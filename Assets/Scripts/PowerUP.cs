using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : FakeGravityBody
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            PlayerEntity player = collision.gameObject.GetComponent<PlayerEntity>();
            player.ActiveInvulnerability();
            Destroy(gameObject);
        }
    }
}
