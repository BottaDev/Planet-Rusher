using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour
{
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
}