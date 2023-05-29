using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1.5f;
    public bool isFlipped = false;
    private Transform player;
    public Transform fauno;
    private Vector2 target;
    Rigidbody2D rb;
    private SpriteRenderer mySprite;
    public int attackDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if(fauno.position.x < player.position.x){
            rb.velocity = new Vector2(speed, -1f);
            mySprite.flipX = true;
            
        }else if(fauno.position.x > player.position.x){
            rb.velocity = new Vector2(-speed, -1f);
            
            
        }
        
        
        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") || other.CompareTag("Terrain")){
            DestroyProjectile();
            if(other.CompareTag("Player")){
                other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
