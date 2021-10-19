/* Andrey Chizhov - 101255069
 * Script was modified to move the background images horizontally from right to left
 * Background transform was modified in editor to sit horizontally
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed;
    public float boundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(boundary, 0.0f);
    }

    private void _Move()
    {
        transform.position -= new Vector3(speed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -boundary)
        {
            _Reset();
        }
    }
}
