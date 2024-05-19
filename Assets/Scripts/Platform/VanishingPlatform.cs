using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float TimeUntilDisappear = 3f;
    [SerializeField] private Color platformSteppedOn;
    [SerializeField] private Color originalColor;
    [SerializeField] private float DelayToActive = 2f;
    [SerializeField] private bool isActive = true;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D circleCollider;
    private float delayPlatform = Mathf.Infinity;

    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<BoxCollider2D>();
        renderer.color = originalColor;
    }

    // Update is called once per frame
    void Update()
    {
        delayPlatform += Time.deltaTime;
        //Debug.Log(isVanished);
        //collider.enabled = isVanished;
        //if(isInactive) 
        // {
        //  var startActive = DelaySetActive();
        //
        //   StartCoroutine(startActive);
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var startInactive = DelaySetInactive();
        


        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            isActive = false;
            Debug.Log("Stepped onto vanishing platform.");
            renderer.color = platformSteppedOn;
            StartCoroutine(startInactive);
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var startInactive = DelaySetInactive();
    //    isVanished = true;


    //    if (collision.gameObject.CompareTag("Player") && isVanished)
    //    {
    //        isVanished = false;
    //        Debug.Log("This platform is gone");
    //        renderer.color = platformSteppedOn;
    //        StartCoroutine(startInactive);
            
    //    }
    //}

    IEnumerator DelaySetInactive()
    {
        yield return new WaitForSeconds(TimeUntilDisappear);
        boxCollider.enabled = false;
        circleCollider.enabled = false;
        renderer.enabled = false;

        yield return new WaitForSeconds(DelayToActive);
        renderer.color = originalColor;
        renderer.enabled = true;
        circleCollider.enabled = true;
        boxCollider.enabled = true;
        //isVanished = false;

        isActive = true;
        yield return null;
    }
}
