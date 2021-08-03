using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public int health = 5;
    public TextMeshProUGUI healthText;
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        UpdateHealth(0);
        loseScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            loseScreen.gameObject.SetActive(true);
        }
    }

    public void UpdateHealth(int healthToTake)
    {
        health -= healthToTake;
        healthText.text = "Health: " + health;
    }
}
