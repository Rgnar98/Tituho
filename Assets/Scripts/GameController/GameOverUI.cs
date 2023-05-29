using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameOverUI : MonoBehaviour
{
    public Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   public void Quit(){
       Debug.Log("APPLICATION QUIT");

        if (EditorApplication.isPlaying){
            UnityEditor.EditorApplication.isPlaying = false;
        } 
        else{
            Application.Quit();
        }
         

   }

   public void Retry(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
