using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : FakeGravityBody
{
    public float speed = 20f;
    public float timeToDestroy = 8f;

    public override void Start()
    {
        base.Start();

        Destroy(gameObject, timeToDestroy);
    }

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
        else if (collision.gameObject.layer == 8)
            Destroy(gameObject);
    }
}
