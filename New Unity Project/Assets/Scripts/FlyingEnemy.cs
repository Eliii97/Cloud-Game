using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private SpriteRenderer enemySprite;
    public int eHealth;
    public bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("dino");
        enemySprite = GetComponent<SpriteRenderer>();

        UpdateEHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "dino")
        {
            isFollowing = true;
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("dirt"))
        {
            UpdateEHealth(1);
            Destroy(collision.gameObject);

            enemyRb.isKinematic = true;
            enemyRb.isKinematic = false;
        }
    }

    public void UpdateEHealth(int eHealthToTake)
    {
        eHealth -= eHealthToTake;
    }
}
