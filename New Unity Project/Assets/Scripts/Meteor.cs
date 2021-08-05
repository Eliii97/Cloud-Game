using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private SpriteRenderer enemySprite;
    public int eHealth = 97;
    public bool isFollowing = false;
    private Animator meteorAnimator;
    public float pounceCounter = 0;
    public float noPounceTime = 0.667f;
    public Vector2 jumpVel;
    public float eagleCounter = 0;
    public float noEagleTime = 5f;
    public GameObject Eagle;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("dino");
        enemySprite = GetComponent<SpriteRenderer>();
        meteorAnimator = GetComponent<Animator>();

        UpdateEHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            eagleCounter += Time.deltaTime;

            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed, 0);

            pounceCounter += Time.deltaTime;
        }

        if (pounceCounter >= noPounceTime)
        {
            if ((player.transform.position.x - transform.position.x) < 0)
            {
                jumpVel = new Vector2(Random.Range(-8f, -12f), Random.Range(7f, 10f));

                Vector2 lookDirection = (player.transform.position - transform.position).normalized;

                enemyRb.velocity = jumpVel;
            }
            else
            {
                jumpVel = new Vector2(Random.Range(8f, 12f), Random.Range(7f, 10f));

                Vector2 lookDirection = (player.transform.position - transform.position).normalized;

                enemyRb.velocity = jumpVel;
            }
                pounceCounter = 0;
        }

        if (eagleCounter >= noEagleTime)
        {
            GameObject rainDrop = Instantiate(Eagle, transform);
            eagleCounter = 0;
        }

            if (enemyRb.velocity.x != 0)
            {
                meteorAnimator.SetBool("meteorWalking", true);
            }
            else
            {
                meteorAnimator.SetBool("meteorWalking", false);
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
            { isFollowing = true; }
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
