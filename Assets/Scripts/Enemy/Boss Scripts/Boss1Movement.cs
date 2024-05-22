using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    /*
     * Having a hard time getting my head around this.
     * Bascially, Boss needs to do its attack, and its attacks are semi-random
     * Afterwards, does a large wind-up animation to show it is going to dash
     * Dashes to end of screen, and does a flurry attack, afterwards
     * slowly marches back to the beginning and resets itself 
     * That's it. 
     * 
     * Boss also damages player if player steps too far into its collider
    */


    [Header("Dash points")]
    [SerializeField] private Transform leftEndpoint;
    [SerializeField] private Transform rightEndpoint;
    public bool readyToDash = false;



    [Header("Movement values")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer = Mathf.Infinity;
    private float waitOnDashCooldown;
    private Vector3 initScale;
    [SerializeField] private bool movingLeft;
    [SerializeField] private float idleDuration;


    [Header("Randomize cycle")]
    [SerializeField] private int cycle1;
    [SerializeField] private int cycle2;

    [Header("Boss")]
    [SerializeField] Transform boss;


    private void Awake()
    {
        initScale = boss.localScale;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToDash)
        {
            DashInDirection();
            readyToDash = false;
        }
    }


    private void DashInDirection()
    {
        boss.position = new Vector3(boss.position.x + Time.deltaTime * dashSpeed,
           boss.position.y, boss.position.z);

    }


    private void DirectionChange()
    {
        boss.localScale = new Vector3(Mathf.Abs(initScale.x) * -1,
            initScale.y, initScale.z);

       
    }


    public bool ReturnToStart() 
    {
        //boss.position = new Vector3(boss)

        return true;
    }
}
