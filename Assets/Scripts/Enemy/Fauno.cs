using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fauno : MonoBehaviour
{
    public Transform player;
    Enemy enemy;

    public float speed = 4f;
    public float stoppingDistance = 2f;
    public float retreatDistance = 2f;

    public GameObject projectile;
    public Transform firePoint;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
    }

    public void Attack(){
        
        Instantiate(projectile, firePoint.position, Quaternion.identity);
         
    }

    void Update(){
        if(enemy.currentHealth <= 0){
            this.enabled = false;
        }
    }
}
