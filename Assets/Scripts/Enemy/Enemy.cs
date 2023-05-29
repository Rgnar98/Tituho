using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;


    public int maxHealth = 100;
    public int currentHealth;
    public int points = 10;
    public GameObject floatingPoints;
    private Transform player;
    private PointsSystem pointSystem;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointSystem = player.GetComponent<PointsSystem>();

     
    
    }

    public void TakeDamage(int damage){
        
        currentHealth -= damage;
        GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){

        pointSystem.TakePoints(points);
        animator.SetBool("IsDead", true);
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D item in colliders)
        {
            item.enabled = false;
        }


    
            
        this.enabled = false;
        
    }

}
