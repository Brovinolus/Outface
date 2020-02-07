using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForMushroom : MonoBehaviour
{
    [SerializeField] GameManager manager;
    // Update is called once per frame
    void Update()
    {
        if(manager.forBug == true && manager.s == true)
        {
            if(gameObject.GetComponent<AudioSource>().isPlaying == false)
                gameObject.GetComponent<AudioSource>().Play();
        }
        else if (manager.s == false)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
