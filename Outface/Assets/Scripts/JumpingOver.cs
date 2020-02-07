using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingOver : MonoBehaviour
{
    bool onPosition;
    private void Update()
    {
        if(onPosition == true)
        {
            ground.SetActive(true);
        }
        else
        {
            ground.SetActive(false);
        }
    }
    public GameObject ground;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GroundCheck"))
        {
            onPosition = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("GroundCheck"))
        {
            onPosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GroundCheck"))
        {
            onPosition = false;
        }
    }
}
