using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// I thought I could  just make Bullet spawn from inspector, but now I need to actuallly
/// just implement this through code. It'll be easier that way, I think
/// Shouldn't be too hard to do.
/// Instead of checking for collisions and all that shit, I just spawn a Bullet, and it does 
/// the rest.
/// Will get that going when I come back from work.
/// </summary>

public class RangeEnemy : MonoBehaviour
{
    [Header("Combat attributes")]
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float respawnTime = 4;
    [SerializeField] bool facingLeft = false;
    [SerializeField] private int damage;

    // Make attackCooldown and initialDelay closer values to each other
    // To decrease the "wind up" time of the initial attack
    [SerializeField] private float attackCooldown;
    [SerializeField] private float initialDelay = 2.5f;


    [SerializeField] private AudioClip projectile;

    private float timer = Mathf.Infinity;
    private int direction;


    [Header("Raycast attributes")]
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;
    //private Animator anim;
    private Player player;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
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

        if (enemyPatrol.movingLeft)
        {
            //Debug.Log("Range enemy moving left");
            
            direction = -1;
            //Debug.Log(direction);

        }
        else if (!enemyPatrol.movingLeft)
        {
            direction = 1;
            //Debug.Log(direction);
        }

        if (PlayerInSight())
        {
            initialDelay += Time.deltaTime; 
            // attack only when player is in sight
            if (cooldownTimer >= attackCooldown && initialDelay >= attackCooldown)
            {
                cooldownTimer = 0;
                //Debug.Log("I am going to attack");
                //anim.SetTrigger("MeleeAttack");
                //Attack

                Shoot();
                
            }
        }

        if (enemyPatrol != null)
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

        if (hit.collider != null)
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


    private void Shoot()
    {
        //Debug.Log("Firing shot");
        //Debug.Log(direction);
        bullets[FindProjectile()].transform.position = bulletPosition.position;
        bullets[FindProjectile()].GetComponent<Bullet>().ActivateProjectile(direction, damage);
        SoundManager.thisInstance.PlaySound(projectile);

        //Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private int FindProjectile()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }

        return 0;

    }

   
}
