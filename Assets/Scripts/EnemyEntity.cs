using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : FakeGravityBody
{
    public int baseHp = 1;
    public float speed = 4f;
    public GameObject deathSound;

    protected bool isFreezed = false;

    protected int currentHp;

    public Animator animator;

    public SpawnPowerUp powerUp;
    public UIManager uiManager;
    private StopperSoounds stopper;

    public override void Awake()
    {
        base.Awake();

        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
        powerUp = GameObject.Find("Planet").GetComponent<SpawnPowerUp>();

        currentHp = baseHp;
    }

    protected virtual void Update()
    {
        if (isFreezed)
            return;

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
        CreateDeathEffect();

        GameObject soundObj = Instantiate(deathSound, transform.position, transform.rotation);
        Destroy(soundObj, 6);

        Destroy(gameObject);
    }

    public void FreezeEnemy(float time)
    {
        isFreezed = true;

        StartCoroutine(UnFreezeEnemy(time));
    }

    private IEnumerator UnFreezeEnemy(float time)
    {
        yield return new WaitForSeconds(time);

        isFreezed = false;

        stopper = GameObject.Find("Stopper Sounds(Clone)").GetComponent<StopperSoounds>();
        stopper.DesactivedPowerUp();

        uiManager.powerUpActived.enabled = false;
        uiManager.powerUpTimeLeftText.enabled = true;
        powerUp.isActived = false;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11 || collision.gameObject.layer == 8)
            KillEnemy();
    }
}
