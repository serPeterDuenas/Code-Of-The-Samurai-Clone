using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    


    [Header("Weapon attributes")]
    public Transform weapon;
    public LayerMask enemyLayerCheck;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private float attackCooldown = 1.5f;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Checks if player is attacking
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)
        {
            //Debug.Log("Im attacking");
            //cooldownTimer += Time.deltaTime;
            //Attack();
            anim.SetBool("Attacking", true);
        }
    }



    private void Attack()
    {
        //anim.SetTrigger("Attack");
        cooldownTimer = 0;
        //anim.SetBool("IsAttacking", false);

        Debug.Log("animation called");
        SoundManager.thisInstance.PlaySound(attackSound);
        //Debug.Log("Attacking -- player");

        // Detect if enemy is in the attack radius
        Collider2D[] enemyCheck = Physics2D.OverlapCircleAll(weapon.position, attackRange, enemyLayerCheck);

        // Damage enemy 

        foreach (Collider2D enemy in enemyCheck)
        {
            Debug.Log("Calling TakeDamage from Player Attack");
            //if(enemy.gameObject.tag == "Range")
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
            Debug.Log("Calling TakeDamage from Player Attack");
        }


        //anim.SetBool("Attack", false);
    }


    public void EndAttack()
    {
        anim.SetBool("Attacking", false);
    }



    // visualize in inspector the attack radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weapon.position, attackRange);
    }
}
