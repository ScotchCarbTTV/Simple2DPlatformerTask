using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int cherries = 0;

    public static ItemCollector Instance;

    [SerializeField] int cherryPoints = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Debug.Log("Instance assigned");
        }
        else
        {
            Debug.Log("There can only be one ItemCollector in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries += cherryPoints;
            cherriesText.text = $"Points: {cherries}\nCollect 1000 points to finish!" ;
        }
    }
}
