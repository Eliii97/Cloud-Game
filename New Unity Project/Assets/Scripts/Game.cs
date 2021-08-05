using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int health = 5;
    public TextMeshProUGUI healthText;
    public GameObject loseScreen;
    public GameObject player;
    public GameObject restart;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        UpdateHealth(0);
        loseScreen.gameObject.SetActive(false);
        player = GameObject.Find("dino");
        //restart = GameObject.Find("restart");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            loseScreen.SetActive(true);
            restart.SetActive(true);
        }
        if (health < 0)
        {
            health = 0;
        }
    }

    public void UpdateHealth(int healthToTake)
    {
        if (health > 0)
        {
            health -= healthToTake;
            healthText.text = "Health: " + health;
        }
    }

    public void loadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
