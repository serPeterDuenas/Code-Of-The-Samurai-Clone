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
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float respawnTime = 4;
    [SerializeField] bool facingLeft = false;
    private float timer = Mathf.Infinity;
    private int direction;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int maxHealth = 100;

    private float cooldownTimer = Mathf.Infinity;
    private int currentHealth = 0;
    //private Animator anim;
    private Player player;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        currentHealth = maxHealth;
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
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        if (PlayerInSight())
        {
            // attack only when player is in sight
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                Debug.Log("I am going to attack");
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
        bullets[FindProjectile()].transform.position = bulletPosition.position;
        bullets[FindProjectile()].GetComponent<Bullet>().ActivateProjectile(direction, damage);
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log("I took damage! -- enemy");

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
