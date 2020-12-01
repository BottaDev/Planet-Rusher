﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : FakeGravityBody
{
    protected void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13 || collision.gameObject.layer == 14)
            DestroyObstacle();
    }

    // For any reason, we have to use this because the collision with the layer 14 is not being detected...
    public void DestroyObstacle()
    {
        CreateDeathEffect();
        Destroy(gameObject);
    }
}
