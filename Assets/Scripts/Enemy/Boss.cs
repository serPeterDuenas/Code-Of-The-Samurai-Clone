using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Dash values")]
    [SerializeField] private Transform endpoint1;
    [SerializeField] private Transform endpoint2;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer = Mathf.Infinity;


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
}
