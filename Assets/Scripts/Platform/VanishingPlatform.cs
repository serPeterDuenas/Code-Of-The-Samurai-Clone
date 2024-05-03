using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    public float TimeUntilDisappear = 3f;
    public Color platformSteppedOn;
    public Color originalColor;
    public float DelayToActive = 2f;


    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color = originalColor;
    }

    // Update is called once per frame
    void Update()
    {
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


        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stepped onto vanishing platform.");
            renderer.color = platformSteppedOn;
            this.gameObject.GetComponent<SpriteRenderer>().color = platformSteppedOn;
            StartCoroutine(startInactive);
        }
    }

    IEnumerator DelaySetInactive()
    {
        yield return new WaitForSeconds(TimeUntilDisappear);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        renderer.enabled = false;
        
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(DelayToActive);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        renderer.enabled = true;

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        renderer.color = originalColor;
 
        yield return null;
    }
}
