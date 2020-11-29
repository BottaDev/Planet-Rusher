using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour
{
    public GameObject explosion;

    private FakeGravity attractor;
    protected Rigidbody rb;

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        attractor = GameObject.Find("Planet").GetComponent<FakeGravity>();
    }

    private void FixedUpdate()
    {
        if (attractor != null)
            attractor.Attract(transform, rb);
        else
            Debug.LogError("Attractor was not found in object: " + gameObject.name);
    }

    protected void CreateDeathEffect()
    {
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(exp, 1f);
    }
}