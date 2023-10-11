using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSelfOnHit : MonoBehaviour
{
    public string[] hideOnHitWith;
    public int scoreToAdd;
    public int numberToAdd;
    public bool hide;
    private GameController gameController;
    [SerializeField]
    public AudioClip coinSound;

    public GameObject explosion;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ball")
        {
            Debug.Log("Yes");
            AudioSource.PlayClipAtPoint(coinSound, gameObject.transform.position);
        }
        
        for(int i = 0; i < hideOnHitWith.Length; i++)
        {
            if (col.transform.CompareTag(hideOnHitWith[i]))
            {
                
                
                gameController.updateScore(scoreToAdd);
                gameController.updatePutts(numberToAdd);
                if (hide) {
                    if (explosion)
                    {
                        Instantiate(explosion, transform.position, transform.rotation);
                        Debug.Log("EXPLODE");
                    }
                    Destroy(gameObject);
                    
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
