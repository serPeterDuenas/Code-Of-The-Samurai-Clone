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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Checks if player is attacking
        if (Input.GetMouseButtonDown(0) && cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;
            Attack();
        }
    }



    private void Attack()
    {
        SoundManager.thisInstance.PlaySound(attackSound);
        //Debug.Log("Attacking -- player");

        // Detect if enemy is in the attack radius
        Collider2D[] enemyCheck = Physics2D.OverlapCircleAll(weapon.position, attackRange, enemyLayerCheck);

        // Damage enemy

        foreach (Collider2D enemy in enemyCheck)
        {
            //if(enemy.gameObject.tag == "Range")
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }




    // visualize in inspector the attack radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weapon.position, attackRange);
    }
}
