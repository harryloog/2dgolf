using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    int scorNum = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void updateScore(int scoreToAdd)
    {
        scorNum += scoreToAdd;
        scoreText.text = "Score: " + scorNum;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
