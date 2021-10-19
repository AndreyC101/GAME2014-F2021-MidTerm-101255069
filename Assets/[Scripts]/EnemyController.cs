﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float boundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, speed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= boundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -boundary)
        {
            direction = 1.0f;
        }
    }
}
