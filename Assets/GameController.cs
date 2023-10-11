using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI puttText;
    private int putts;
    private int score;
    public int maxPutts;

    private bool hasPowerUp = false;
    public GameObject[] powerUpUI;
    private int pupNumber;
    public GameObject bullet;
    private GameObject instance;

    public int enemyNormalSpeed;
    public int enemySpeedChange;
    [HideInInspector]
    public float enemySpeed;

    public GameObject ball;

    private bool timerOn=false;
    private float timer;
    public int pupDuration = 12;

    public AudioClip shootSound;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Scenes : " + SceneManager.sceneCountInBuildSettings + "\n" + "Current Scene : " +SceneManager.GetActiveScene().buildIndex);
        putts = 0;
        score = 0;
        for (int i = 0; i < powerUpUI.Length; i++)
        {
            powerUpUI[i].SetActive(false);
            enemySpeed = enemyNormalSpeed;
        }
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            if (PlayerPrefs.HasKey("current"))
            {
                PlayerPrefs.DeleteKey("current");
            }
        }

        if (PlayerPrefs.HasKey("current"))
        {
            int temp = PlayerPrefs.GetInt("current");
            updateScore(temp);
        }
        else
        {
            updateScore(0);
        }
            updatePutts(0);
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void updatePutts(int numberToAdd)
    {
        putts += numberToAdd;
        puttText.text = "Putts: " + putts + "/" + maxPutts;
    }

    public int getPutts()
    {
        return putts;
    }

    // Update is called once per frame
    public bool addPowerUp(int pup)
    {
        if (!hasPowerUp)
        {
            powerUpUI[pup].SetActive(true);
            hasPowerUp = true;
            pupNumber = pup;
            return true;
        }
        else { return false; }
    }

    public void restartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextScene()
    {
        PlayerPrefs.SetInt("current", score);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            if (PlayerPrefs.HasKey("scoreTable")) 
            {
                ScoreElement scoreElement = new ScoreElement(score);
                Debug.Log(JsonUtility.ToJson(scoreElement));
                ScoreTable scoreTable = JsonUtility.FromJson<ScoreTable>(PlayerPrefs.GetString("scoreTable"));
                Debug.Log(JsonUtility.ToJson(scoreTable));
                scoreTable.scoreTable.Add(scoreElement);
                Debug.Log(JsonUtility.ToJson(scoreTable));
                PlayerPrefs.SetString("scoreTable", JsonUtility.ToJson(scoreTable));
                PlayerPrefs.Save();
            } else 
            {
                ScoreElement scoreElement = new ScoreElement(score);
                ScoreTable scoreTable = new ScoreTable();
                scoreTable.scoreTable.Add(scoreElement);
                PlayerPrefs.SetString("scoreTable", JsonUtility.ToJson(scoreTable));
                PlayerPrefs.Save();
            }
            
            PlayerPrefs.DeleteKey("current");
            PlayerPrefs.SetInt("sh", 1);
            PlayerPrefs.Save();
            GameObject mp = GameObject.FindGameObjectWithTag("Music");
            if (mp.GetComponent<MusicPlayer>())
            {
                mp.GetComponent<MusicPlayer>().StopMusic();
            }            
            SceneManager.LoadScene(0);

        }
    }

    void Update()
    {   
        timer += Time.deltaTime;
        if (Input.GetMouseButton(1) && hasPowerUp)
        {
            hasPowerUp = false;
            if (pupNumber == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    instance = Instantiate(bullet, ball.transform.position, Quaternion.Euler(Vector3.forward * i * 45));
                    

                }
                powerUpUI[pupNumber].SetActive(false);
                AudioSource.PlayClipAtPoint(shootSound, gameObject.transform.position);
            }
            if (pupNumber == 1)
            {
                enemySpeed = enemyNormalSpeed - enemySpeedChange;
                timerOn = true;
                timer = 0;
                powerUpUI[pupNumber].SetActive(false);
            }
        }

        if (Input.GetKeyDown("r")) 
        {
            restartScene();
        }

        if (Input.GetKeyDown("escape"))
        {
            PlayerPrefs.DeleteKey("current");
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
            SceneManager.LoadScene(0);
        }

        if (timer > pupDuration && timerOn)
        {
            enemySpeed = enemyNormalSpeed;
            timerOn = false;
        }

        if (putts > maxPutts)
        {
            restartScene();
        }
    }
}