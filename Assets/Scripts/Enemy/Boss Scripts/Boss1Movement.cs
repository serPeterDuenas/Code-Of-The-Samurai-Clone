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
    [SerializeField] private float idleDuration;


    [Header("Randomize cycle")]
    [SerializeField] private int cycle1;
    [SerializeField] private int cycle2;

    [Header("Boss")]
    [SerializeField] Transform boss;

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
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }


    private void DirectionChange()
    {
        waitOnDashCooldown += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
}
