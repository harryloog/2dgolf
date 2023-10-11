using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Powerbar : MonoBehaviour
{
    Slider slider;
    Vector2 force;
    GameObject gameObject;



    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.FindGameObjectWithTag("Player");
        slider = GetComponent<Slider>();
        slider.maxValue = 50;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //force = GameObject.FindGameObjectWithTag("Player").GetComponent<DragToHit>().powerValue;
        if (Input.GetMouseButton(0))
        {
            Debug.Log((Math.Abs(Input.mousePosition.x) - Math.Abs(gameObject.transform.position.x)) +
                      (Math.Abs(Input.mousePosition.y) - Math.Abs(gameObject.transform.position.y)) * 10);
            slider.value = (Math.Abs(Input.mousePosition.x) - Math.Abs(gameObject.transform.position.x)) +
                (Math.Abs(Input.mousePosition.y) - Math.Abs(gameObject.transform.position.y)) * 10;
        } else { slider.value = 0; }
        
        // if (Mathf.Abs(force.x) < 1) { force.x = 1.5f; }
        // if (Mathf.Abs(force.z) < 1) { force.z = 1.5f; }
        // slider.value = (Mathf.Abs(force.x) + Mathf.Abs(force.z)) / 2;
      
    }
}
