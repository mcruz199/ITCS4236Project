using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    private float points = 0f;
    public Text counterText;
    public Text scoreText;
    [SerializeField] private float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        counterText.text = "HEALTH: " + health.ToString() + "/100";
        scoreText.text = "SCORE: " + points.ToString();
    }

    public void UpdateHealth(float mod)
    {
        Debug.Log(health);
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            SceneManager.LoadScene("Game Over");
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    public void UpdateScore(float mod)
    {
        points += mod;
    }
}
