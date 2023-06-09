﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunoMovement : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;

    public bool isFlipped = false;

    public void LookAtPlayer(){
        Vector3 flipped = transform.localScale;
        Quaternion rotate = Quaternion.Euler(0, 0, 180);
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped){
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped){
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            firePoint.rotation *= rotate;
            isFlipped = true;
        }
    }
}
