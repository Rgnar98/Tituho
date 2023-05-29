using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    public Transform player;
    PlayerHealth playerHealth;
    PlayerAttack playerAttack;
    PointsSystem pointsSystem;

    void Start(){
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAttack = player.GetComponent<PlayerAttack>();
        pointsSystem = player.GetComponent<PointsSystem>();
    }

    public void SavePlayer(){
        playerHealth.currentHealth = playerHealth.maxHealth;
        playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
        SaveSystem.SavePlayer(playerHealth, playerAttack, pointsSystem);
    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        playerHealth.currentHealth = data.health;
        playerAttack.currentMana = data.mana;
        pointsSystem.initialPoints = data.points;
        

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.position = position;

        SceneManager.LoadScene(data.scene);

    }
}
