using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    public int degrees = 360;

    public int speed = 10;
    // Start is called before the first frame update
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.forward * degrees * Time.deltaTime * gameController.enemySpeed;
    }
}
