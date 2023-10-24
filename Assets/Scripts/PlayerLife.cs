using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    [SerializeField] int playerLivesMax;
    [SerializeField] int livesRemainingWarning;
    int livesRemaining;
    [SerializeField] Text livesRemainingText;

    Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        livesRemaining = playerLivesMax;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        livesRemainingText.text = $"Lives: {livesRemaining}";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        if (livesRemaining == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            livesRemaining--;
            if (livesRemaining > livesRemainingWarning)
            {
                livesRemainingText.text = $"Lives: {livesRemaining}";
            }
            else
            {
                livesRemainingText.text = $"Lives: {livesRemaining}\n WARNING: LOW HEALTH!";
            }
            transform.position = spawnPoint;
            rb.bodyType = RigidbodyType2D.Dynamic;
            anim.SetTrigger("respawn");
        }
    }
}
