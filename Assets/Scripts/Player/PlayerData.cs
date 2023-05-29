using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int mana;
    public int points;
    public string scene;
    public float[] position;

    public PlayerData(PlayerHealth playerHealth, PlayerAttack playerAttack, PointsSystem pointsSystem){
        health = playerHealth.currentHealth;
        mana = playerAttack.currentMana;
        points = pointsSystem.initialPoints;
        scene = SceneManager.GetActiveScene().name;

        position = new float[3];
        position[0] = playerHealth.transform.position.x;
        position[1] = playerHealth.transform.position.y;
        position[2] = playerHealth.transform.position.z;
    }

  
}
