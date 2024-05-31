using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private Player player;
    [SerializeField] private int damage = 5;
    private BoxCollider2D coll;
    private float returnColliderTime = 0.5f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            player.TakeDamage(damage);


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coll.enabled = false;

            if(timer >= returnColliderTime)
            {
                coll.enabled = true;
                timer = 0;
            }
                
        }
    }
}
