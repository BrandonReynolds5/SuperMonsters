using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        //Code for monsters to chase player
        if(isChasing)
        {
            //If player is to the left of monster then have it go left
            if(transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1,1,1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            //If player is to the right of monster then have it go right
            if(transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1,1,1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else{
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            if(patrolDestination == 0)
            {
                //Make enemy move to patrol point at set speed towards dest 1 if reached 0
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1,1,1);
                    patrolDestination = 1;
                }
            }

            if(patrolDestination == 1)
            {
                //Make enemy move to patrol point at set speed towards dest 0 if reached 1
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if(Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1,1,1);
                    patrolDestination = 0;
                }
            }
        }
    }
}

