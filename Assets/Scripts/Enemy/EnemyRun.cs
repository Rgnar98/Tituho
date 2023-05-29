using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyRun : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(aiPath.desiredVelocity.x));
        if(aiPath.desiredVelocity.x >= 0.01f){
            
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if(aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
