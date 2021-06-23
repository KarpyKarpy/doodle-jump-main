using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


namespace DoodleJump
{
    // This is the save system able to be called from anywhere.
    public static class Save
    {
        // This will save the inputed player
        public static void SavePlayer(PlayerHS _player)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/LastPlayer.hss";

            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(_player);

            formatter.Serialize(stream, data);

            stream.Close();
        }

        //Saves the last score to the list
        public static void SavePlayerToList(PlayerHS _player)
        {
            string path = Application.persistentDataPath + "/playerHSList.hss";

            if (!File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);
                HighScoreList HSdata = new HighScoreList();
                formatter.Serialize(stream, HSdata);
                stream.Close();
            }
  

           
            BinaryFormatter formatter2 = new BinaryFormatter();

            
            FileStream stream2 = new FileStream(path, FileMode.Open);

            
            HighScoreList data = new HighScoreList();

            
            PlayerData data3 = new PlayerData(_player);

            
            data = formatter2.Deserialize(stream2) as HighScoreList;

            
            stream2.Close();

            
            data.myHighScoreList.Add(data3);

            
            BinaryFormatter formatter3 = new BinaryFormatter();

           
            FileStream stream3 = new FileStream(path, FileMode.Open);

            
            formatter2.Serialize(stream3, data);

            
            stream2.Close();
        }

        //This loads the last score
        public static PlayerData LoadPlayer()
        {
            
            string path = Application.persistentDataPath + "/LastPlayer.hss";

            
            if (File.Exists(path))
            {
                
                BinaryFormatter formatter = new BinaryFormatter();

               
                FileStream stream = new FileStream(path, FileMode.Open);

                
                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                
                stream.Close();
                
                return data;
            }
            
            
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }

        // loads highscores in a list.
        public static HighScoreList LoadHighScoreList()
        {
           
            string path = Application.persistentDataPath + "/playerHSList.hss";

           
            if (File.Exists(path))
            {
                
                BinaryFormatter formatter = new BinaryFormatter();
                
                FileStream stream = new FileStream(path, FileMode.Open);
               
                HighScoreList data = formatter.Deserialize(stream) as HighScoreList;
               
                stream.Close();
               
                return data;
            }
            
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }

        
    }
}