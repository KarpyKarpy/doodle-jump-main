using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace DoodleJump
{
    // This will be attached to an empty game object in the GamePlay scene in inspector. It will hold the current Runs Score and Save it.
    public class HighScore : MonoBehaviour
    {
        public Text myHighScoreText;            
        [HideInInspector] public float myHighScore;

        //starts the high score at zero
        void Start()
        {
            myHighScore = 0;
        }

        //score increases by game time
        void LateUpdate()
        {
            myHighScore += Time.deltaTime;
            // Displays the "HighScore" or more accuratly "This Run Score" to 1 decimal place in the Score
            myHighScoreText.text = myHighScore.ToString("F1");
        }
    }
}