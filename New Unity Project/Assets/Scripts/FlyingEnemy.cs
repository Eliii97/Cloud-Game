﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private SpriteRenderer enemySprite;
    private int eHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("dino");
        enemySprite = GetComponent<SpriteRenderer>();

        eHealth = 3;
        UpdateEHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (enemyRb.velocity.x > 0)
        {
            enemySprite.flipX = true;
        }
        else
        {
            enemySprite.flipX = false;
        }

        if (eHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateEHealth(int eHealthToTake)
    {
        eHealth -= eHealthToTake;
    }
}
