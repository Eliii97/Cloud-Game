using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailEnemy : MonoBehaviour
{
    public float speed = 0.0133f;
    public int eHealth = 1;
    private SpriteRenderer enemySprite;
    private Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -1 * speed);

        if (eHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UpdateEHealth(1);
        
        Destroy(collision.gameObject);
    }

    public void UpdateEHealth(int eHealthToTake)
    {
        eHealth -= eHealthToTake;
    }

}
