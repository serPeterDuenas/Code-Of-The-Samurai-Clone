using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// All enemies will have this script so the Player will only need to check this script


public class Health : MonoBehaviour
{

    [SerializeField] private bool isShielded = false;
    [SerializeField] private AudioClip damageClip;
    [SerializeField] private AudioClip shieldBreakClip;
    [SerializeField] private int maxHealth = 100;
    private bool takenDamage = false;
    public int currentHealth = 0;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public bool IsShielded()
    {
        return isShielded;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Calling TakeDamage");

        if(isShielded && !takenDamage)
        {
            anim.SetBool("IsShielded", false);
            Debug.Log("Shield break");
            isShielded = false;
            SoundManager.thisInstance.PlaySound(shieldBreakClip);
        }
        else if(takenDamage && !isShielded)
        {
            Debug.Log("Take damage ");
            currentHealth -= damage;
            SoundManager.thisInstance.PlaySound(damageClip);
        }
        else if (!takenDamage && !isShielded)
        {
            Debug.Log("Take damage ");
            currentHealth -= damage;
            SoundManager.thisInstance.PlaySound(damageClip);
        }


            if (currentHealth <= 0)
        {
            //Debug.Log(currentHealth);
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
