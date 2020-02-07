using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    [SerializeField]
    private GameObject player;
    public GameObject jumpingSurface;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            //player.GetComponent<Animator>().ResetTrigger("Jump");
            player.GetComponent<Animator>().SetBool("Landing", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    
     /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            player.GetComponent<Animator>().ResetTrigger("Jump");
            player.GetComponent<Animator>().SetBool("Landing", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }*/
}
