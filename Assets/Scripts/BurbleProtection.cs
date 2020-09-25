using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbleProtection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
            PlayerEntity player = collision.gameObject.GetComponent<PlayerEntity>();
            player.DesactiveInvulnerability();
        }
    }
}
