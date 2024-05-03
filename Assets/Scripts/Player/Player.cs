using System;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    //[Header("Movement controls")]// Player's movement controls
    //[SerializeField] private float moveSpeed = 15f;
    //[SerializeField] private float acceleration = 50f;
    //[SerializeField] private int jumpPower = 15;
    //[SerializeField] private float jumpResistance = 10f;
    //public Transform groundCheck;
    //public LayerMask groundLayer;
    ////[SerializeField] private bool spawnFacingLeft = false;
    //private bool isFacingRight;
    //private float moveX;
    //private int moveDirection;
    //private Rigidbody2D rb;
    //// Player's logic for moving platform
    //public bool isOnPlatform = false;
    //public Rigidbody2D platformRB;

    [Header("Health attributes")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int CurrentHealth = 0;
    

    //[Header("Weapon attributes")]
    //public Transform weapon;
    //public LayerMask enemyLayerCheck;
    //[SerializeField] private float attackRange = 0.5f;
    //[SerializeField] private int attackDamage = 10;


    


    public void TakeDamage(int damageValue)
    {
        //Debug.Log("I took damage -- player");
        CurrentHealth -= damageValue;
        healthBar.SetHealth(CurrentHealth);
        //Debug.Log("I have this much health: ");
        //Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0 )
        {
            KillPlayer();
        }
    }


    public static void KillPlayer()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    private void Awake()
    {
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


   


    private void Update()
    {
        

    }











    
}
