/* Andrey Chizhov - 101255069
 * Script was modified to move the player character vertically between screen bounds
 * Player transform was modified in editor to face to the right
 */
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float verticalBoundary;

    [Header("Player Speed")]
    public float verticalSpeed;
    public float maxSpeed;
    public float verticalValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }
    private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % fireDelay == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }
    private void _Move()
    {
        float direction = 0.0f;
        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }
            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }
            m_touchesEnded = worldTouch;
        }
        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }
        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }
        if (m_touchesEnded.x != 0.0f)
        {
           transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check upper bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }
        // check lower bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }
    }
}