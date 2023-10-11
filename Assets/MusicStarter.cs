using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public GameObject audio;
    // Start is called before the first frame update
    void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Music"))
        {
            Instantiate(audio, transform.position, transform.rotation);
        }
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();

    }
}
