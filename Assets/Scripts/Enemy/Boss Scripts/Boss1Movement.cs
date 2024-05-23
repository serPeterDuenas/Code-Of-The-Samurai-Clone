using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{

    [Header("Movement values")]
    [SerializeField] private Transform leftEndpoint;
    [SerializeField] private Transform rightEndpoint;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float waitUntilReset;
    [SerializeField] private float walkSpeed;
    public bool readyToDash = false;

    [Header("Boss")]
    [SerializeField] private Transform boss;


    private Vector3 initScale;
    private bool returnToStart;
    private float idleTimer;





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
        if (returnToStart)
        {
            if (boss.position.x >= leftEndpoint.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else if (readyToDash)
        {
            if (boss.position.x <= rightEndpoint.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        boss.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        if(_direction == 1)
        {
            boss.position = new Vector3(boss.position.x + Time.deltaTime * _direction * dashSpeed,
           boss.position.y, boss.position.z);
        }
        else
        {
            boss.position = new Vector3(boss.position.x + Time.deltaTime * _direction * walkSpeed,
           boss.position.y, boss.position.z) ;
        }

       
    }


    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > waitUntilReset)
            returnToStart = !returnToStart;
    }
}
