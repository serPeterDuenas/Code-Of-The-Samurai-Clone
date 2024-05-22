using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    [Header("Dash points")]
    [SerializeField] private Transform leftEndpoint;
    [SerializeField] private Transform rightEndpoint;




    [Header("Movement values")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer = Mathf.Infinity;
    [SerializeField] private bool readyDashRight = true;
    [SerializeField] private bool readyDashLeft = false;
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
        //initScale = enemy.localScale;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void DashInDirection(int _direction)
    {
        waitOnDashCooldown = 0;
        boss.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        boss.position = new Vector3(boss.position.x + Time.deltaTime * _direction * dashSpeed,
            boss.position.y, boss.position.z);
    }


    private void DirectionChange()
    {
        waitOnDashCooldown += Time.deltaTime;

        if (waitOnDashCooldown > idleDuration)
            movingLeft = !movingLeft;
    }
}
