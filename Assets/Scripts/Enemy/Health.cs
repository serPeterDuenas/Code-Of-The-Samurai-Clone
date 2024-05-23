using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// All enemies will have this script so the Player will only need to check this script


public class Health : MonoBehaviour
{


    [SerializeField] private AudioClip damageClip;
    [SerializeField] private int maxHealth = 100;
    public int currentHealth = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SoundManager.thisInstance.PlaySound(damageClip);
        

        if (currentHealth <= 0)
        {
            //Debug.Log(currentHealth);
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
