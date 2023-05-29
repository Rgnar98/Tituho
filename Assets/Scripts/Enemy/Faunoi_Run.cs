using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faunoi_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 10f;
    public float timeBtwShots = 2f;
    float nextAttackTime = 0f;
    

    Transform player;
    Rigidbody2D rb;
    FaunoMovement fauno;
    PlayerHealth playerHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        rb = animator.GetComponent<Rigidbody2D>();
        fauno = animator.GetComponent<FaunoMovement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fauno.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        if(playerHealth.currentHealth > 0 && Vector2.Distance(player.position, rb.position) > attackRange){
            rb.MovePosition(newPos);
        }else if(playerHealth.currentHealth <= 0) {
            animator.SetBool("PlayerIsDead", true);
        }

        if(Vector2.Distance(player.position, rb.position) <= attackRange && playerHealth.currentHealth > 0 && Time.time >= nextAttackTime){
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / timeBtwShots;  
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        
    }
}
