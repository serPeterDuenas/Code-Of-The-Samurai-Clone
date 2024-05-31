using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // logic for the movement of the object in game space
    public GameObject ways;
    public Transform[] wayPoints;
    public float moveSpeed = 5f;
    private Vector3 target;
    private int pointIndex;
    private int pointCount;
    private int direction = 1;


    //logic to check if player is on platform, adds velocity to player and gravity
    private PlayerMovement player;
    private Rigidbody2D rb;
    private Vector3 moveDirection;
    private Rigidbody2D playerRB;

    // to set delay of platform when reaching end point
    public float waitDuration = 1f;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }


    private void Start()
    {
        pointIndex = 0;
        pointCount = wayPoints.Length;
        target = wayPoints[0].transform.position;
        CalculateDirection();
    }

    private void Update()
    {
        // if the object's position is at Point A, then target B
        if (Vector2.Distance(transform.position, target) < 0.05f)
        {
            NextPoint();
        }


        //transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

            

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }


    public void NextPoint()
    {
        transform.position = target;
        moveDirection = Vector3.zero;

        // arrived at the final point of index
        if(pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        // arrived to the first point of index
        if(pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        target = wayPoints[pointIndex].transform.position;
        StartCoroutine(WaitNextPoint());
    }


    IEnumerator WaitNextPoint()
    {
        yield return new WaitForSeconds(waitDuration);
        CalculateDirection();
    }


    private void CalculateDirection()
    {
        moveDirection = (target - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);


            player.isOnPlatform = true;
            player.platformRB = rb;
            playerRB.gravityScale = playerRB.gravityScale * 50;
            Debug.Log("On platform");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

            player.isOnPlatform = false;
            playerRB.gravityScale = playerRB.gravityScale / 50;
            Debug.Log("Off platform");
        }
    }
}
