using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public GameObject projectile;
    public Transform firePoint;

    private PlayerHealth playerHealth;
    public HealthBar manaBar;

    public float attackFireRate = 1f;
    public int maxMana = 50;
    public int currentMana = 50;
    public int fireMana = 5;
    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private Shake shake;

    void Start(){
        playerHealth = GetComponent<PlayerHealth>();
        //currentMana = maxMana;
        manaBar.SetMaxHealth(maxMana);
        manaBar.SetHealth(currentMana);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){

            if(Input.GetButtonDown("Fire1")){
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if(Input.GetButtonDown("Fire2") && currentMana >= fireMana){
                Attack2();
                nextAttackTime = Time.time + 1f / attackFireRate;
            }
        
        }


        if(playerHealth.currentHealth <= 0)
            this.enabled = false;
        
    }

    void Attack(){
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            shake.CamShake();
            
        }

    }

     void Attack2(){
        animator.SetTrigger("Attack2");
        currentMana -= fireMana;
        manaBar.SetHealth(currentMana);
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        
        

    }

    void OnDrawGizmosSelected(){

        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
