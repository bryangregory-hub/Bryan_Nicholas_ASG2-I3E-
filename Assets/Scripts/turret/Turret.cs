using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    
    public string enemyTag = "Enemy";
    public string playerTag = "Player";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public string[] test;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject _Player;
    private bool isNotWall;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
        
    }
    /// <summary>
    /// Check less frequently and find in the scene if gameobj tag is present add to the string
    /// checks if the gameobj tag is closest to the turret and face it
    /// if no gameobj of tag is present return null
    /// </summary>
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject[] player = GameObject.FindGameObjectsWithTag(playerTag);

         test = new string[enemies.Length + player.Length];
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy!=null&&shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    /// <summary>
    /// this checks everyframe the direction of the target and smoothly faces it with lerp
    /// </summary>
    void Update()
    {
        inNotBlock();
        if (target==null)
        {
            return;
        }

        print(test);
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

        if (fireCountDown <=0&& isNotWall == true)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    
    void Shoot()
    {
        GameObject bulletMove=(GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bulletMove.transform.rotation = bulletSpawn.transform.rotation;
    }

    void inNotBlock()
    {
        int laymask = LayerMask.NameToLayer("Walls");
        RaycastHit ray;
        if (Physics.Raycast(transform.position,transform.forward,out ray, range,laymask))
        {
            isNotWall = false;
        }
        else
        {
            isNotWall = true;
        }
    }
    /// <summary>
    /// provides a visualisetion of the radius of the the turret 
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
