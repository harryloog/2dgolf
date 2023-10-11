using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string hideOnHitWith = "";
    public int PowerUpNumber;
    private GameController gameController;

    [SerializeField]
    public AudioClip coinSound;
    // Start is called before the first frame update
    void Start()
    {
 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag(hideOnHitWith))
        {

            if (gameController.addPowerUp(PowerUpNumber) == true)
            {
                AudioSource.PlayClipAtPoint(coinSound, gameObject.transform.position);
                Destroy(gameObject);
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
