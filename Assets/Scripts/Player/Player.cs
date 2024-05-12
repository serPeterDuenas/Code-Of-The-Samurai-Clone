using System;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    [Header("Health attributes")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int CurrentHealth = 0;
    [SerializeField] private int totalLives = 5;

    [SerializeField] private LivesManager livesManager;
    [SerializeField] private GameManager gameManager;
    private bool isDead = false;

    


    public void TakeDamage(int damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.SetHealth(CurrentHealth);


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
        gameManager = FindObjectOfType<GameManager>();
    }

    public void KillPlayer()
    {
        Respawn();
        livesManager.UpdateLives();
        gameManager.ResetScene();
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
