using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Animator animator;
    private Rigidbody2D rb;
    //public GameObject hurtUI;
    public GameObject floatingPoints;

    public HealthBar healthBar;
    public bool damaged;
    Collider2D col;

    [SerializeField]
    private GameObject gameOverUI;

    private Shake shake;
    public float bounceStrength;

    
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        col = GetComponent<Collider2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        damaged = false;

        /* if(hurtUI.GetComponent<Image>().color.a > 0){
            var color = hurtUI.GetComponent<Image>().color;
            color.a -= 0.1f;

            hurtUI.GetComponent<Image>().color = color;
        } */
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(5);
            //rb.velocity = new Vector2((transform.position.x - col.attachedRigidbody.position.x) * 25 , rb.velocity.y);
            Bounce(col.attachedRigidbody.position.x);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Enemy"){
            TakeDamage(5);  
            Bounce(collision.transform.position.x);
            //rb.velocity = new Vector2((transform.position.x - collision.transform.position.x) * 25 , rb.velocity.y);
        }
            
    }

    public void Bounce(float position){
        rb.velocity = new Vector2((transform.position.x - position) * bounceStrength , rb.velocity.y);
    }

    public void TakeDamage(int damage){
        damaged = true;
        shake.CamShake();
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        //var color = hurtUI.GetComponent<Image>().color;
        //color.a = 0.8f;
        
        GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().color = new Color(1f, 0f, 0f);
        points.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();


        if(currentHealth <= 0){
            Die();
        }
        
    }

    void Die(){

        //Die animation
        animator.SetBool("IsDead", true);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        EndGame();
        
    }

    public void EndGame(){
        gameOverUI.SetActive(true);

        //hurtUI.SetActive(false);
    }

}
