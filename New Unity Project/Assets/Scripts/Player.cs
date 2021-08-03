using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public float bulletSpeed;
    public Rigidbody2D playerRb;
    public float jumpForce;
    public float horizontalInput;
    public GameObject dirt;
    public bool hasBeenHit = false;
    public bool invulnerable = false;
    public float invulnerableCounter = 0;
    public float invulnerableTime = 2.5f;
    private Game game;
    private Animator dinoAnimator;
    private SpriteRenderer dinoSprite;
    

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        dinoAnimator = GetComponent<Animator>();
        dinoSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if player is Alive (Health <= 0)

        Vector2 velocity = playerRb.velocity;

        velocity.x = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space) && playerRb.velocity.y < 0.05 && playerRb.velocity.y > -0.05)
        {
            velocity.y = jumpForce;
        }
        
        if (playerRb.velocity.x != 0)
        {
            dinoAnimator.SetBool("isWalking", true);
        }
        else
        {
            dinoAnimator.SetBool("isWalking", false);
        }

        if(playerRb.velocity.x < 0)
        {
            dinoSprite.flipX = true;
        }
        else if(playerRb.velocity.x > 0)
        {
            dinoSprite.flipX = false;
        }

        if (hasBeenHit)
            invulnerable = true;

        if (invulnerable)
        {
            invulnerableCounter += Time.deltaTime;

            if(invulnerableCounter >= invulnerableTime)
            {
                invulnerable = false;
                hasBeenHit = false;
            }
        }



        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            GameObject bullet = Instantiate(dirt, transform);

            if (dinoSprite.flipX == true)
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * bulletSpeed, 0);

            else
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * bulletSpeed, 0);
        }

        //transform.Translate(Vector2.right * speed * horizontalInput);

        playerRb.velocity = velocity;

        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // If collide with enemy, health -= 1;
        if (collision.gameObject.CompareTag("EnemyWeak"))
        {
            game.UpdateHealth(1);
            
        }

        if(collision.gameObject.CompareTag("Enemy") && !invulnerable)
        {
            game.UpdateHealth(1);
            hasBeenHit = true;
        }
    }

   
}
