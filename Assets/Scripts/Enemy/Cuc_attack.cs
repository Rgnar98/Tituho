using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuc_attack : MonoBehaviour
{
    Enemy enemy;
    public Transform player;
    public float speed = 1.5f;
    public int attackDamage = 2;
    Rigidbody2D rb;
    private bool m_FacingRight = false;
    public int distanceStop = 2;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

            
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            
        }
    }
}
