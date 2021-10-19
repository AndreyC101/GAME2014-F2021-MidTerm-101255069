/* Andrey Chizhov - 101255069
 * Script was modified to move the enemy character vertically between screen bounds
 * enemy transform was modified in editor prefab to face to the left
 */

using System.Collections;
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
        // translate on the y axis
        transform.position += new Vector3(0.0f, speed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check upper boundary
        if (transform.position.y >= boundary)
        {
            direction = -1.0f;
        }

        // check lower boundary
        if (transform.position.y <= -boundary)
        {
            direction = 1.0f;
        }
    }
}
