using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragToHit : MonoBehaviour
{
    [SerializeField]
     private float power = 1f;
    [SerializeField]
     private Rigidbody2D rb;
    [HideInInspector]
    public int counter = 0;

    private AudioSource hitAudio;
    public Slider slider;
    private bool startselected = false;
     

    public Vector2 minPower;
    public  Vector2 maxPower;

    private Camera cam;

    Vector2 force;
    Vector2 force2;
    Vector3 startPoint;
    Vector3 endPoint;

    Color green = new Color(0, 255, 0);
    Color white = new Color(255, 255, 255);

    Renderer renderer;
    bool dodieanimonce = false;
    bool canHit = true;
    private GameController gameController;

    public AudioClip shootSound;
    public GameObject explosion;


    void Awake()
    {
        renderer = GetComponent<Renderer>();


        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        slider = GetComponentInChildren<Slider>();
        hitAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canHit){
            renderer.material.color = green;
        }else{
            renderer.material.color = white;
        }
        if (Input.GetMouseButtonDown(0) && canHit)
        {
            startPoint = cam.ScreenToWorldPoint((Input.mousePosition));
            startPoint.z = 15;
            startselected = true;
        }

        if (Input.GetMouseButton(0) && canHit && startselected)
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint((Input.mousePosition));
            currentPoint.z = 15;
            if ((Math.Abs(currentPoint.x) - Math.Abs(transform.position.x)) < maxPower.x || (Math.Abs(currentPoint.x) - Math.Abs(transform.position.x)) < Math.Abs(minPower.x) || (Math.Abs(currentPoint.y) - Math.Abs(transform.position.y)) < maxPower.y ||
                (Math.Abs(currentPoint.y) - Math.Abs(transform.position.y)) < Math.Abs(minPower.y))
            {
                slider.value = (Math.Abs(Math.Abs(currentPoint.x) - Math.Abs(transform.position.x)) +
                                 Math.Abs(Math.Abs(currentPoint.y) - Math.Abs(transform.position.y))) * 10;
            }
            
        }

        if (Input.GetMouseButtonUp(0) && canHit && startselected)
        {

            endPoint =cam.ScreenToWorldPoint((Input.mousePosition));
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));


            hitAudio.Play();
            rb.AddForce(force * power, ForceMode2D.Impulse);
            slider.value = 0;

            gameController.updatePutts(1);
            canHit = false;
            startselected = false;
        }
        
        //Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude < 0.3f && !canHit)
        {
            rb.velocity = Vector3.zero;
        }
        
        checkHit();
        
        
    }

    private void checkHit()
    {
        if (rb.velocity.magnitude == 0 && gameController.getPutts() == gameController.maxPutts && !dodieanimonce) 
        {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(shootSound, gameObject.transform.position);
            dodieanimonce = true;
        }
        if (rb.velocity.magnitude == 0)
        {
            canHit = true;
        }
    }
    
}
