using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTendaBoscController : SceneController
{
    public Transform player;
 
    // Use this for initialization
    public override void Start () {
        base.Start();
 
        if (prevScene == "Bosc01") {
            player.position = new Vector2(40.9f, -2.51f);
            //Camera.main.transform.position = new Vector3(36.7f, 0.2f, -10f);
        }
    }
}
