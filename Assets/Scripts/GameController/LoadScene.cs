using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string toScene;
    private SceneController sceneController;

    void Start(){
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
           sceneController.LoadScene(toScene);

        }
    }
}
