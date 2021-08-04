using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coznix : MonoBehaviour
{
    public bool isFollowing = false;
    public GameObject Vex;
    private SpriteRenderer enemySprite;
    public int eHealth = 30;
    public float vexSpawnCounter = 0;
    public float vexSpawnWaitTime = 8f;
    private Rigidbody2D enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("dino");
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            vexSpawnCounter += Time.deltaTime;
            if (vexSpawnCounter >= vexSpawnWaitTime)
            {
                GameObject rainDrop = Instantiate(Vex, transform);
                vexSpawnCounter = 0;
            }
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
