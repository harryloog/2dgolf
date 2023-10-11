using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private GameController gameController;

    public AudioClip shootSound;

    public GameObject explosion;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("ball"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(shootSound, gameObject.transform.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
