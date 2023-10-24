using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    public bool isBot;

    private SpriteRenderer botSprite;

    private void Start()
    {
        if (isBot)
        {
            botSprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        float previousX = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        if(isBot)
        {
            if (transform.position.x < previousX && botSprite.flipX)
            {
                botSprite.flipX = false;
            }
            else if (transform.position.x > previousX && !botSprite.flipX)
            {
                botSprite.flipX = true;
            }
        }        
    }
}
