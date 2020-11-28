using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : FakeGravityBody
{
    public int baseHp = 1;
    public float speed = 4f;
    public GameObject deathSound;

    protected int currentHp;

    public Animator animator;

    public override void Awake()
    {
        base.Awake();

        currentHp = baseHp;
    }

    protected virtual void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public virtual void TakeDamage()
    {
        currentHp--;

        if (currentHp <= 0)
            KillEnemy();
    }

    protected void KillEnemy()
    {
        GameObject soundObj = Instantiate(deathSound, transform.position, transform.rotation);
        Destroy(soundObj, 1f);
        Destroy(gameObject);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
            KillEnemy();
        }
        else if (collision.gameObject.layer == 11 || collision.gameObject.layer == 8)
            KillEnemy();
    }
}
