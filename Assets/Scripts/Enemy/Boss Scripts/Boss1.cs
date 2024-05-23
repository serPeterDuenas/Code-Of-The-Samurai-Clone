using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator anim;

    private Boss1Movement movementPattern;
    private bool standingLeft = true;

    [Header("Attack values")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Player player;
    [SerializeField] private AudioClip attack;
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackCooldownTimer = Mathf.Infinity;

    [Header("Body collider")]
    [SerializeField] private BoxCollider2D bodyCollider;


    private void Awake()
    {
    }



    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(currentHealth);
        movementPattern = GetComponentInParent<Boss1Movement>();
    }




    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(attackDamage);
        }
    }

}
