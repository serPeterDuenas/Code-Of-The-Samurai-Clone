using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public int damage;
    private float lifetime;
    private float bulletDuration = 5;
    //private Animator anim;
    private BoxCollider2D coll;
    private Player player;
    private int direction;

    //private bool hit;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile(int _direction, int _damage)
    {
        direction = _direction;
        //Debug.Log(direction);
        damage = _damage;
        //hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;

        var localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y,
            transform.localScale.z);
    }
    private void Update()
    {
        //if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > bulletDuration)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hit = true;

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("bullet collided with player");
            player = collision.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //hit = true;
        coll.enabled = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
