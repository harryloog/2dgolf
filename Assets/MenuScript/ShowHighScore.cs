using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("sh")) 
        {
            if (PlayerPrefs.GetInt("sh") == 1) 
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.GetComponent<LoadHighScores>().LoadHighScore();
            }
            PlayerPrefs.DeleteKey("sh");
        }
    }

}
