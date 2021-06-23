using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


namespace DoodleJump
{
    public class Load : MonoBehaviour
    {
        public HighScoreList highScoreList;
        public PlayerData lastScore;

        // This is the TextBoxes to display the Highscores and the Score from the previous run.
        public Text displayHighScores;          // <--- !!! TO BE SET IN INSPECTOR!!!
        public Text displayLastScore;           // <--- !!! TO BE SET IN INSPECTOR!!!

       
        void Start()
        {
            // Gets all previous Scores saved from all runs
            highScoreList = Save.LoadHighScoreList();

            // Gets the Players Last Run Score
            lastScore = Save.LoadPlayer();

            // Sorts all the scores by fastest time
            highScoreList.myHighScoreList.Sort();

            // Displays all or top 10 Highscores
            for (int i = 0; i < highScoreList.myHighScoreList.Count && i < 10; i++)
            {
                // Displays Each Score and Player name, then makes a new line in the HighScore text box.
                displayHighScores.text = (displayHighScores.text + highScoreList.myHighScoreList[i].PName + " " + highScoreList.myHighScoreList[i].PScore.ToString("F1") + "\n");
            }
            
            // Displays the score from the last run in the last run text box.
            displayLastScore.text = ("Your Score = " + lastScore.PName + " " + lastScore.PScore.ToString("F1"));
        }

       
    }
}
