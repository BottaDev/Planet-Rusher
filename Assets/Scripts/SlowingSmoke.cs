using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingSmoke : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Player
        if (other.gameObject.layer == 8)
            other.gameObject.GetComponent<PlayerEntity>().ChangeMovementSpeed(true);
    }

    private void OnTriggerExit(Collider other)
    {
        // Player
        if (other.gameObject.layer == 8)
            other.gameObject.GetComponent<PlayerEntity>().ChangeMovementSpeed(false);
    }
}
