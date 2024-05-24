using System;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private AudioClip damageSound;
    private bool isDead = false;

    


    public void TakeDamage(int damageValue)
    {
        currentHealth -= damageValue;
        healthBar.SetHealth(currentHealth);
        SoundManager.thisInstance.PlaySound(damageSound);

        if (currentHealth <= 0 )
        {
            KillPlayer();
        }
    }

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        livesManager = FindObjectOfType<LivesManager>();
    }

    public void KillPlayer()
    {
            livesManager.UpdateLives();
            GameManager.thisInstance.ResetScene();
            Respawn();
    }


    private void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        //var scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
    }

   


   


    private void Update()
    {
        if (isDead)
        {
            //Respawn();
            isDead = false;
        }
        else
            return;

    }











    
}
