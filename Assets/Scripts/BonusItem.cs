using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    // Start is called before the first frame update

    

    [SerializeField] private float bonusItemTimer;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(bonusItemTimer >= 0)
        {
            bonusItemTimer -= Time.deltaTime;
            return;
        }
        gameObject.SetActive(false);

    }
}
