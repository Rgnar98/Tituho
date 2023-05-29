using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoletJumping : MonoBehaviour
{
    public Animator anim;
    public float strength;
    

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            
            anim.SetTrigger("Jump");
            other.GetComponent<Rigidbody2D>().velocity = Vector2.up * strength;
        }
        

    }
}
