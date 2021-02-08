using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbleProtection : MonoBehaviour
{
    private PlayerEntity player;

    private void Awake()
    {
        player = gameObject.GetComponentInParent<PlayerEntity>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Obstacle obs = collision.gameObject.GetComponent<Obstacle>();

            if (obs != null)
                obs.DestroyObstacle();

            player.DesactiveInvulnerability();
        }
        else if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject);
            player.DesactiveInvulnerability();
        }
    }
}
