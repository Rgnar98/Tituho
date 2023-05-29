using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Controller : SceneController
{
    public Transform player;
    public Transform firePoint;
 
    // Use this for initialization
    public override void Start () {
        base.Start();
 
        if (prevScene == "BoscTenda") {
            player.position = new Vector2(-9.1f, -2.51f);
            //Camera.main.transform.position = new Vector3(36.7f, 0.2f, -10f);
        }else if (prevScene == "Bosc02"){
            player.position = new Vector2(19.3f, -2.51f);
        }
    }
}
