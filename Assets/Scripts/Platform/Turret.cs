using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // This class takes an object, and after a set time, will respawn them into the scene
    // Uses an ammo system that goes through the list until iterated through

    [SerializeField] private AudioClip projectile;

    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float timeBetweenShots = 4f;
    [SerializeField] bool facingLeft = false;
    public int damage;

    // Set this float closer but below the value of "timeBetweenShots"
    // to make Bullet spawn faster upon loading scene
    [SerializeField] private float initialDelay = 1.5f;

    private int direction;


    // Start is called before the first frame update
    void Start()
    {
        //bullets = new GameObject[bullets.Length];

        if(facingLeft)
        {
            direction = -1;
            //var reverseDirection = -bullet.transform.localScale;
            //bullet.transform.localScale = reverseDirection;
        }
        else
        {
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        initialDelay += Time.deltaTime;

        if(initialDelay >= timeBetweenShots)
        {
            initialDelay = 0;
            Shoot();
        }
    }


    private void Shoot()
    {
        SoundManager.thisInstance.PlaySound(projectile);

        bullets[FindProjectile()].transform.position = bulletPosition.position;
        bullets[FindProjectile()].GetComponent<Bullet>().ActivateProjectile(direction, damage);
        //Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private int FindProjectile()
    {
        for(int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }

        return 0;

    }
}
