using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Controller : SceneController
{
    public Transform player;
 
    // Use this for initialization
    public override void Start () {
        base.Start();
 
        if (prevScene == "Bosc02") {
            player.position = new Vector2(-14f, -2.51f);
            //Camera.main.transform.position = new Vector3(36.7f, 0.2f, -10f);
        } else if(prevScene == "Bosc04"){
            player.position = new Vector2(9.5f, -2.51f);
        }
    }
}
