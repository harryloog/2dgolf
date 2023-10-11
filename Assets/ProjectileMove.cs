using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public int projectileSpeed = 10;
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
        transform.position += transform.right * (gameController.enemySpeed / gameController.enemyNormalSpeed) * projectileSpeed * Time.deltaTime ;
    }
    
}
