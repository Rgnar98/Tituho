using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Controller : SceneController
{
   public Transform player;
 
    // Use this for initialization
    public override void Start () {
        base.Start();
 
        if (prevScene == "Bosc03") {
            player.position = new Vector2(-10f, -2.51f);
            //Camera.main.transform.position = new Vector3(36.7f, 0.2f, -10f);
        } else if(prevScene == "Bosc05"){
            player.position = new Vector2(19.51f, -2.51f);
        }
    }
}
