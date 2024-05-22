using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{


    [Header("Attack values")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private AudioClip attack;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackCooldownTimer = Mathf.Infinity;


    // Start is called before the first frame update
    void Start()
    {
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
