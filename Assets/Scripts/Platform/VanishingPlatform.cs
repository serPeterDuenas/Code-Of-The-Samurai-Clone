using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float TimeUntilDisappear = 3f;
    [SerializeField] private Color platformSteppedOn;
    [SerializeField] private Color originalColor;
    [SerializeField] private float DelayToActive = 2f;
    [SerializeField] private bool isVanished = false;
    private BoxCollider2D collider;

    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        renderer.color = originalColor;
    }

    // Update is called once per frame
    void Update()
    {
        //collider.enabled = isVanished;
        //if(isInactive) 
        // {
        //  var startActive = DelaySetActive();
        //
        //   StartCoroutine(startActive);
        //}
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var startInactive = DelaySetInactive();
    //    isVanished = true;


    //    if (collision.gameObject.CompareTag("Player") && isVanished)
    //    {
    //        //Debug.Log("Stepped onto vanishing platform.");
    //        renderer.color = platformSteppedOn;
    //        this.gameObject.GetComponent<SpriteRenderer>().color = platformSteppedOn;
    //        StartCoroutine(startInactive);
    //    }
    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var startInactive = DelaySetInactive();
        isVanished = true;


        if (collision.gameObject.CompareTag("Player") && isVanished)
        {
            //Debug.Log("Stepped onto vanishing platform.");
            renderer.color = platformSteppedOn;
            this.gameObject.GetComponent<SpriteRenderer>().color = platformSteppedOn;
            StartCoroutine(startInactive);
        }
    }

    IEnumerator DelaySetInactive()
    {
        yield return new WaitForSeconds(TimeUntilDisappear);
        collider.enabled = false;
        renderer.enabled = false;
        
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(DelayToActive);
        collider.enabled = true;
        renderer.enabled = true;

        //this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        renderer.color = originalColor;
        yield return null;

        isVanished = false;
    }
}
