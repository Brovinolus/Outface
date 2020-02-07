using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransCamera : MonoBehaviour
{
    public GameObject flip;

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

 
    void LateUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        RotateCamera();
        RotateCamera2();
    }

    public bool a = false;
    bool b = true;
    public GameObject target;
    private void RotateCamera2()
    {
        if (Input.GetKeyDown(KeyCode.X) && b == true)
        {
            a = !a;
            b = false;
            player.SetActive(false);
            StartCoroutine("Rotating2");
        }
    }

    private Vector3 target2 = new Vector3(0.0f, -6.0f, 0.0f);
    IEnumerator Rotating2()
    {
        if (a == true)
        {
            for (i = 0; i < 100; i++)
            {
                transform.eulerAngles += new Vector3(0, 0, 1.8f);
                transform.position += new Vector3(0, -0.1f, 0);
                //player.transform.position += new Vector3(0, -0.1f, 0);

                yield return new WaitForSeconds(.01f);
            }
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y * -1, player.transform.position.z);
        }
        if (a == false)
        {
            for (i = 0; i < 100; i++)
            {
                transform.eulerAngles += new Vector3(0, 0, 1.8f);
                transform.position += new Vector3(0, 0.1f, 0);
                //player.transform.position += new Vector3(0, 0.1f, 0);

                yield return new WaitForSeconds(.01f);
            }
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y * -1, player.transform.position.z);
        }
        player.GetComponent<Rigidbody2D>().gravityScale *= -1;
        player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1, player.transform.localScale.z);
        player.GetComponent<Movement>().jumpForce *= -1;
        player.GetComponent<Movement>().movementSpeed *= -1;
        player.SetActive(true);
        b = true;
        /*
        for (i = 0; i < 180; i++)
        {
            //transform.RotateAround(target.transform.position, Vector3.back, 1);
            //transform.RotateAround(target2, Vector3.back, 1);
            yield return new WaitForSeconds(.01f);
        }*/
    }

    //Vector3 theScale;
    bool s;
    private void RotateCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            s = !s;
            player.SetActive(false);
            StartCoroutine("Rotating");
        }
    }
    int i = 0;
    int y = 0;
    
    IEnumerator Rotating()
    {
        for (i= 0; i < 180; i++)
        {
            transform.eulerAngles += new Vector3(0, 0, 1);

            yield return new WaitForSeconds(.01f);
        }

        for (y = 0; y > -11; y--)
        {
            if (s == true)
            {
                player.transform.position += new Vector3(0, -1f, 0);
                player.GetComponent<Rigidbody2D>().gravityScale = -1;
                flip.GetComponent<Flip>().facingRight = false;
            }
            else if (s == false)
            {
                player.transform.position += new Vector3(0, 1f, 0);
                player.GetComponent<Rigidbody2D>().gravityScale = 1;
                flip.GetComponent<Flip>().facingRight = true;// исправить баг
            }

                yield return new WaitForSeconds(.1f);
        }

        player.transform.localScale = new Vector3(player.transform.localScale.x, player.transform.localScale.y * -1 , player.transform.localScale.z);

        i = 0;
        y = 0;
        player.SetActive(true);
        player.GetComponent<Movement>().jumpForce *= -1;
        player.GetComponent<Movement>().movementSpeed *= -1;
    }

    /*
        
        //Position of the character is stored here
        private Transform playerTransform;
        //reference to playerTransform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //we store current camera's position in variable temp - temporary position(can be edited)
        Vector3 temp = transform.position;

        //we set the camera's position x to be equal to the player's position x
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        //we set back the camera's position temp position to the camera's position
        transform.position = temp;
     */
}

