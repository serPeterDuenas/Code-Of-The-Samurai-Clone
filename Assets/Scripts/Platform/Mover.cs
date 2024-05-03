using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // logic for the movement of the object in game space
    public Transform pointA, pointB;
    public float moveSpeed = 5f;
    public float pauseDelay = 1f;
    private float initDelay;
    private Vector3 target;
    private Vector3 initA, initB;

    //logic to check if player is on platform, adds velocity to player
    //private Player player;
    //private Rigidbody2D rb;
    //private Vector3 moveDirection;





    //private void Awake()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //    rb = GetComponent<Rigidbody2D>();
    //}


    private void Start()
    {
        // this is done so that the points can be child of this object, a workaround
        initA = pointA.position;
        initB = pointB.position;
        target = initA;
        initDelay = pauseDelay;
    }

    private void Update()
    {
        if (pauseDelay == 0)
        {
            // if the object's position is at Initial Point A, then target B
            if (Vector3.Distance(transform.position, initA) < 0.001f)
            {
                target = initB;
            }
            // if the object's pos is at Initial Point B, then target A
            else if (Vector3.Distance(transform.position, initB) < 0.001f)
            {
                target = initA;
            }
        }


        // If platform reaches pointA, target PointB and start moving in that direction
        if (Vector3.Distance(transform.position, initA) < 0.001f)
        {
            if (pauseDelay > 0)
            {
                pauseDelay -= Time.deltaTime;
                if (pauseDelay <= 0.01f)
                {
                    pauseDelay += initDelay;
                    target = initB;
                }
            }
        }
        else if (Vector3.Distance(transform.position, initB) < 0.001f)
        {
            if (pauseDelay > 0)
            {
                pauseDelay -= Time.deltaTime;
                if (pauseDelay <= 0.01f)
                {
                    pauseDelay += initDelay;
                    target = initA;
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }


    //private void FixedUpdate()
    //{
    //    rb.velocity = moveDirection * moveSpeed;
    //}

    //private void CalculateDirection()
    //{
    //    moveDirection = (target - transform.position.normalized);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        player.isOnPlatform = true;
    //        player.platformRB = rb;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        player.isOnPlatform = false;
    //    }
    //}
}
