using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    [SerializeField] int finishScoreRequirement;

    private bool levelCompleted = false;

    [SerializeField] GameObject notEnough;

    private void Start()
    {
        notEnough.SetActive(false);
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            if (ItemCollector.Instance.cherries == finishScoreRequirement)
            {
                finishSound.Play();
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            }
            else
            {
                notEnough.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        notEnough.SetActive(false);
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
