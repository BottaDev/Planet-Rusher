using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravity : MonoBehaviour
{
    public float minSize;
    public float gravity = -50;

    private float xRest;
    private float yRest;
    private float zRest;

    private void Update()
    {
        if (transform.localScale.x > minSize && transform.localScale.y > minSize && transform.localScale.z > minSize)
            ShrinkPlanet();
    }

    private void ShrinkPlanet()
    {
        xRest -= 0.5f * Time.deltaTime;
        yRest -= 0.5f * Time.deltaTime;
        zRest -= 0.5f * Time.deltaTime;

        transform.localScale = new Vector3(50 + xRest, 50 + yRest, 50 + zRest);
    }

    public void Attract(Transform objBody, Rigidbody rigBody)
    {
        // Set planet gravity direction for the object body
        Vector3 gravityDir = (objBody.position - transform.position).normalized;
        Vector3 bodyUp = objBody.up;

        // Apply gravity to objects rigidbody
        rigBody.AddForce(gravityDir * gravity);

        // Update the objects rotation in relation to the planet
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityDir) * objBody.rotation;    // Rotacion que hay entre bodyUp y gravityDIr

        // Smooth rotation
        objBody.rotation = Quaternion.Slerp(objBody.rotation, targetRotation, 50 * Time.fixedDeltaTime);
    }
}
