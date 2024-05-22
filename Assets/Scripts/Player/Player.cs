using System;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int CurrentHealth = 0;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private AudioClip damageSound;
    private bool isDead = false;

    


    public void TakeDamage(int damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.SetHealth(CurrentHealth);
        SoundManager.thisInstance.PlaySound(damageSound);

        if (CurrentHealth <= 0 )
        {
            KillPlayer();
        }
    }

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        livesManager = FindObjectOfType<LivesManager>();
    }

    public void KillPlayer()
    {
        Respawn();
        livesManager.UpdateLives();
        GameManager.thisInstance.ResetScene();
    }


    private void Respawn()
    {
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        //var scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
    }

   


   


    private void Update()
    {
        if(isDead)
        {
            Respawn();
            isDead = false;
        }

    }











    
}
