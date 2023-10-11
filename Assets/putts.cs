using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class putts : MonoBehaviour
{
    int putt = 0;
    public TextMeshProUGUI puttText;
    public GameObject counter;

    public int max;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        putt = counter.GetComponent<DragToHit>().counter;
        puttText.text = "Putts: " + putt + "/" + max;
        if (counter.GetComponent<DragToHit>().counter > max) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
