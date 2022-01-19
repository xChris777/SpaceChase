using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void ModifyScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
        //Debug.Log($"Score is now: {score}");
    }
    
        
    

}
  