using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : FakeGravityBody
{
    public GameObject obstacle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Instantiate(obstacle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 10)
            Destroy(gameObject);
    }
}
