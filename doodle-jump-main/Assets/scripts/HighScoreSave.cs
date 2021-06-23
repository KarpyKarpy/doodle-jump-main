using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace DoodleJump
{
    // Called in Game to Submit and Save the current Score
    public class HighScoreSave : MonoBehaviour
    {
        public HighScore myScore;               // <--- !!! TO BE SET IN INSPECTOR!!!
        public float myFinalScore;
        public string myName;
        public Text myFinalScoreText;           // <--- !!! TO BE SET IN INSPECTOR!!!

        //the final score
        void Update()
        {
            myFinalScore = myScore.myHighScore;
            myFinalScoreText.text = myFinalScore.ToString("F1");
        }

        // lets player input the name
        public void ReadStringInput(string s)
        {
            myName = s;
        }

        //saves the score
        public void SubmitScore()
        {
            PlayerHS _PlayerHS = new PlayerHS();

            _PlayerHS.Name = myName;

            _PlayerHS.Score = myFinalScore;

            Save.SavePlayer(_PlayerHS);

            Save.SavePlayerToList(_PlayerHS);

            SceneManager.LoadScene(4);
        }
    }

    //stores player name and score
    public class PlayerHS
    {
        public string Name;
        public float Score;
    }
}