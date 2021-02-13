using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : FakeGravityBody
{
    public float speed = 20f;
    public float timeToDestroy = 8f;
    private PlayerInput player;

    public override void Start()
    {
        base.Start();

        if (gameObject.layer == 13)
            player = GameObject.Find("Player").GetComponent<PlayerInput>();

        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<EnemyEntity>().TakeDamage();
            ApplyCD();
        }
        else if(collision.gameObject.layer == 10)
        {
            ApplyCD();
        }
        else if (collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            Destroy(collision.gameObject);
        }
            

        if (collision.gameObject.layer != 9)
            Destroy(gameObject);
    }

    private void ApplyCD()
    {
        if (gameObject.layer == 13)
            player.ApplyFastCD();
    }
}
