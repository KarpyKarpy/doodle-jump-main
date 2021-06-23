using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DoodleJump
{

    [System.Serializable]
    // List of HighScores to display.
    public class HighScoreList
    {
        public List<PlayerData> myHighScoreList = new List<PlayerData>();
    }


    [System.Serializable]
    public class PlayerData : IComparable<PlayerData>
    {
        
        public string PName;
        public float PScore;



        //it will save a "PlayerHS" to this "player data".
        public PlayerData(PlayerHS _PlayerHS)
        {
            // Saves Player Name and Score
            PName = _PlayerHS.Name;
            PScore = _PlayerHS.Score;
        }

        // This will give us the smallest one first
        public int CompareTo(PlayerData _Player)
        {
            // If there is nothing in the given "Player data"
            if (_Player == null)
            {
                
                return 1;
            }
            

            //makes the score an int
           
            float x1 = PScore * 100;
            int x2 = Mathf.RoundToInt(x1);
            // The inputed Player Score.
            float y1 = _Player.PScore * 100;
            int y2 = Mathf.RoundToInt(y1);
            // makes it so that they will sort from smallest to largest.
            return x2 - y2;
        }
    }

   
   
}
