using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
