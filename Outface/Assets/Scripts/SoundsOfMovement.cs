using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsOfMovement : MonoBehaviour
{
    [SerializeField]
    AudioSource[] foosteps;
    AudioSource currentClip;
    [SerializeField]
    AudioSource jump1;
    [SerializeField]
    AudioSource jump2;
    int index;
    public float delay;
    [SerializeField]
    public bool wait;
    public bool pause;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Foosteps();
        Jump();
    }
    void Foosteps()
    {
        if(gameObject.GetComponent<Movement>().isGrounded == true && gameObject.GetComponent<Movement>().movementSpeed > 0 && pause == false)
        {
            if (wait == false)
            {
                StartCoroutine(PlayFoosteps());
                wait = true;
            }
        }
    }

    IEnumerator PlayFoosteps()
    {
        index = Random.Range(0, foosteps.Length);
        currentClip = foosteps[index];
        print(currentClip);
        currentClip.Play();
        yield return new WaitForSeconds(delay);
        wait = false;
    }

    void Jump()
    {
        if(gameObject.GetComponent<Movement>().soundJump2 == true)
        {
            if (jump1.isPlaying == false)
                jump1.Play();
            gameObject.GetComponent<Movement>().soundJump2 = false;
        }
        else if (gameObject.GetComponent<Movement>().soundJump1 == true)
        {
            if (jump2.isPlaying == false)
                jump2.Play();
            gameObject.GetComponent<Movement>().soundJump1 = false;
        }
    }
}
