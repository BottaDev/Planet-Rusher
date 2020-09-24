using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : FakeGravityBody
{
    public float speed = 4f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
