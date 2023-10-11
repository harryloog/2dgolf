using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    
    float timer = 0;
    int waitingTime = 2;
    private GameObject newProjectile;
    public AudioClip shootSound;

    public GameObject projectileObject;
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
        timer += Time.deltaTime;
        if(timer * gameController.enemySpeed / gameController.enemyNormalSpeed > waitingTime)
        {
            AudioSource.PlayClipAtPoint(shootSound, gameObject.transform.position);
            newProjectile = Instantiate(projectileObject, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
