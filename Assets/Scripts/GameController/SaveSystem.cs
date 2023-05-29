using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem {

    public static void SavePlayer (PlayerHealth playerHealth, PlayerAttack playerAttack, PointsSystem pointsSystem){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerHealth, playerAttack, pointsSystem);

        formatter.Serialize(stream, data);
        Debug.Log("Save file in " + path);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            
            stream.Close();
            Debug.Log("Load file in " + path);

            return data;
        }else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
  
}
