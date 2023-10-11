using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAfterAnim : MonoBehaviour
{
    private float timer;
    private float time;
    private float delay = 0f;
    private GameController gameController;
    // Start is called before the first frame update

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        // Start is called before the first frame update
   
        time = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            Destroy(gameObject);
            gameController.nextScene();
        }
    }
}
