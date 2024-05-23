using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private Boss1Movement movementPattern;
    private bool standingLeft = true;

    [Header("Attack values")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private AudioClip attack;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackCooldownTimer = Mathf.Infinity;


    // Start is called before the first frame update
    void Start()
    {
        movementPattern = GetComponentInParent<Boss1Movement>();
        //movementPattern.readyToDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void DashRight()
    {
        //transform.position 
    }


    private void DashLeft() { }
}
