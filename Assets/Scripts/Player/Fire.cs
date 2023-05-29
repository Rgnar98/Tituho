using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 20f;
    public bool isFlipped = false;
    private Transform player;
    Rigidbody2D rb;
    private SpriteRenderer mySprite;
    public int attackDamage = 1;
    public float maxLifeFire = 2f;
    public float lifeFire;

    private Shake shake;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        mySprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifeFire = maxLifeFire;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeFire-=0.1f;
        if (lifeFire <= 0){
            DestroyProjectile();
            lifeFire = maxLifeFire;
        }
            
    

        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy") || other.CompareTag("Terrain")){
            DestroyProjectile();
            if(other.CompareTag("Enemy")){
                shake.CamShake();
                other.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
