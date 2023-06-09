﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandidoWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public Transform attackPoint;
    private Enemy enemy;

    void Start(){
        enemy = GetComponent<Enemy>();
    }

    void Update(){
        if(enemy.currentHealth <= 0){
            this.enabled = false;
        }
    }

    public void Attack(){
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, attackMask);
        if(colInfo != null){
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            colInfo.GetComponent<PlayerHealth>().Bounce(transform.position.x);
        }
    }

    void OnDrawGizmosSelected(){

        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
