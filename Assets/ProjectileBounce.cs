using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBounce : MonoBehaviour
{
    public int projectileSpeed = 10;
    Rigidbody2D rb;
    Vector2 lastVelocity;
    public int bounces;
    private int counter;
    public string bounceFrom = "";
    private GameController gameController;


    // Update is called once per frame
    void Update()
    {

    }


    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        counter = 0;
        // Apply your initial velocity on spawn.
        // Then you don't need to transform the object every update tick.
        rb.velocity = transform.right * (gameController.enemySpeed / gameController.enemyNormalSpeed) * projectileSpeed;
    }

    // Do this in FixedUpdate, so you're caching the velocity in every
    // physics step, rather than only on rendered frames.
    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(bounceFrom)) {
            counter += 1;
            if (counter <= bounces)
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
                rb.velocity = direction * Mathf.Max((gameController.enemySpeed / gameController.enemyNormalSpeed) * projectileSpeed, 2f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}