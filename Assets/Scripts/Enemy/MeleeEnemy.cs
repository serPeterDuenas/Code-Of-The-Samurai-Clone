using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    // Set these two variables closer in value to reduce time between
    // The first attack when spotting Player
    [SerializeField] private float attackCooldown;
    [SerializeField] private float initialDelay = 0.5f;


    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private AudioClip attack;

    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Player player;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //currentHealth = maxHealth;
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            initialDelay += Time.deltaTime; 
            // attack only when player is in sight
            if (cooldownTimer >= attackCooldown && initialDelay >= attackCooldown)
            {
                cooldownTimer = 0;
                //Debug.Log("I am going to attack");
                anim.SetTrigger("Attack");
                SoundManager.thisInstance.PlaySound(attack);
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }


    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * colliderDistance
            * transform.localScale.x, new Vector3(boxCollider.bounds.size.x * range,
            boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if(hit.collider != null) 
        {
            player = hit.transform.GetComponent<Player>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range,
            boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    private void DamagePlayer()
    {
        // if player is in range, then do damage
        if (PlayerInSight())
        {
            //Debug.Log("I attacked -- enemy");
            player.TakeDamage(damage);
        }
    }
}
