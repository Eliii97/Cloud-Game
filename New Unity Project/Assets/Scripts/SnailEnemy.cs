using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailEnemy : MonoBehaviour
{
    public float speed = 0.0133f;
    public int eHealth = 1;
    public bool isFollowing = false;
    private SpriteRenderer enemySprite;
    private Rigidbody2D enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("dino");
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
            transform.Translate(Vector3.right * -1 * speed);

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
