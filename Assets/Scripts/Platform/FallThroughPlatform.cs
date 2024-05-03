using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughPlatform : MonoBehaviour
{
    private Collider2D collider;
    private bool playerOnPlatform;
    [SerializeField] private float returnToPlatform = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }


    private IEnumerator EnableCollider () 
    {
        yield return new WaitForSeconds(returnToPlatform);
        collider.enabled = true;
    }


    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null) 
        {
            playerOnPlatform = value;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetPlayerOnPlatform(collision, value:true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SetPlayerOnPlatform(collision, value: true);
    }
}
