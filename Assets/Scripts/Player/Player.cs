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
    private int currentLives;


    //[SerializeField] private LevelManager levelManager;
    [SerializeField] private LivesManager livesManager;
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
        //levelManager = FindObjectOfType<LevelManager>();
        livesManager = FindObjectOfType<LivesManager>();
        currentLives = totalLives;

        //DontDestroyOnLoad(gameObject);
    }

    public void KillPlayer()
    {
        //levelManager.RespawnPlayer();
        Respawn();
        //Checkpoint.RespawnPlayer();
    }


    private void Respawn()
    {
        int takeAwayLife = 1;

        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        livesManager.UpdateLives(takeAwayLife);
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
