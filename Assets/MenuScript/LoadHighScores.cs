using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadHighScores : MonoBehaviour
{
    private TextMeshProUGUI highScores;

    public void LoadHighScore()
    {
        highScores = GameObject.FindGameObjectWithTag("HighScores").GetComponent<TextMeshProUGUI>();
        Debug.Log("No problems here!");
        ScoreTable scoreTable = JsonUtility.FromJson<ScoreTable>(PlayerPrefs.GetString("scoreTable"));
        int highscore = 0;
        for(int i = 0; i < scoreTable.scoreTable.Count; i++) 
        {
            if (scoreTable.scoreTable[i].score > highscore) 
            {
                highscore = scoreTable.scoreTable[i].score;
            }
            Debug.Log(scoreTable.scoreTable[i].score);
        }
        highScores.text = highscore.ToString();
    }
}
