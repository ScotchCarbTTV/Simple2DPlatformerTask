using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarThrow : MonoBehaviour
{

    [SerializeField] GameObject starPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ThrowStar();
        }
    }

    private void ThrowStar()
    {
        GameObject newStar =  GameObject.Instantiate(starPrefab, transform.position, Quaternion.identity);

        if(newStar.TryGetComponent<Rigidbody2D>(out Rigidbody2D starRb))
        {
            starRb.AddForceX(20, ForceMode2D.Impulse)
        }

    }
}
