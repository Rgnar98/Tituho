using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gllineta : MonoBehaviour
{
    public Animator animator;
    public float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0.2f && timer>=0.1f)
            timer = 5.0f;
            

        timer -= 0.01f;
        animator.SetFloat("Timer", timer);
        
        
    
    }
}
