using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    //empty variable
    private Rigidbody2D myRigidbody;

    public Animator animator;

    //public bool isGrounded = false;

    [SerializeField]
    public float movementSpeed;
    private bool run;
    public bool jump;
    [SerializeField]
    public float jumpForce = 300f;
    public GameManager manager;
    [SerializeField]
    private GameObject groundCheck;
    public bool isGrounded;
    bool nextLayer;
    public bool stop;

    void Start()
    {
        //added reference to variable myRigidbody
        myRigidbody = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {

        //HandleLayers();
        HandleInput();
        if (gameObject.GetComponent<Flip>().facingRight == true)
        {
            animator.SetBool("FacingRight", true);
        }
        else if (gameObject.GetComponent<Flip>().facingRight == false)
        {
            animator.SetBool("FacingRight", false);
        }

        if (isGrounded == true)
        {
            animator.SetFloat("Speed", Mathf.Abs(movementSpeed));
        }
     
        isGrounded = groundCheck.GetComponent<GroundCheck>().isGrounded;
        
    }
    bool goingUp;
    void FixedUpdate()
    {
        
        //reference
        float horizontal = Input.GetAxis("Horizontal");

        Move(horizontal);

        OnLanding();

        Jump();

    }

    private void HandleInput()
    {
        if (Input.GetKey("left shift"))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true /*&& finished == false*/ && nextJump == true)
        {
            //manager.notJumping = false;
            finish = false;
            manager.ready = false;
            stopJump = false;
            //finished = true;
            jump = true;
            nextJump = false;
            gameObject.GetComponent<SoundsOfMovement>().pause = true;
            //StartCoroutine(wait());
        }
    }

    private void Jump()
    {  
        if (jump == true)
        {
            jump = false;
            animator.SetTrigger("Jump");
            // Add a vertical force to the player.
            //movementSpeed = 1.0f;
        }   
    }

    float i;
    public bool finished;
    public float timeForJump;
    IEnumerator wait()
    {
        for (i = 0; i <= 1.0f; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(timeForJump);
        }
        finished = false;
    }

    void OnLanding()
    {
        if (isGrounded == true)
        {
            down = true;
        }
        else
        {
            down = false;
        }
    }

    public bool nextJump;
    bool down;
    bool landed;
    public bool finish;
    bool stopMovement;
    bool stopJump = true;
    public bool soundJump1;
    public bool soundJump2;
    bool done;
    public bool treePushing;

    bool up;
    private void Up()
    {
        if (isGrounded == true && up == false)
        {
            myRigidbody.AddForce(new Vector2(0f, jumpForce));
            soundJump1 = true;
            stopJump = true;
            up = true;
        }
    }
    void Landed()
    {
        finish = true;
        landed = true;
    }
    void Landing()
    {
        landed = false;
        manager.ready = false;
        //manager.notJumping = false;
        stopMovement = false;
        finish = false;
        done = false;
    }

    private void Move(float horizontal)
    {
        
        if(myRigidbody.velocity.y < 0 && isGrounded == false)
        {
            animator.SetBool("Landing", true);
        }
        //Здесь была ошибка с зациклинной фнимацией
        else if (myRigidbody.velocity.y >= 0 || isGrounded == true)
        {
            animator.SetBool("Landing", false);
            //down = true;
        }

        if (down == true && finish == false && done == false)
        {
            animator.SetBool("Landed", true);
            //landed = true;
            soundJump2 = true;
            gameObject.GetComponent<SoundsOfMovement>().pause = false;
            done = true;
        }
        else if (finish == true && landed == true)
        {
            nextJump = true;
            landed = false;
            manager.ready = true;
            //manager.notJumping = true;
            animator.SetBool("Landed", false);
            stopMovement = true;
            up = false;
            //done = true;
        }
        //landed = false;


        if (isGrounded == true && stopMovement == true && stopJump == true)
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }
        else if (isGrounded == false && gameObject.GetComponent<Flip>().facingRight == true && Input.GetAxis("Horizontal") > 0)
        {
            myRigidbody.velocity = new Vector2(horizontal * 1.0f, myRigidbody.velocity.y);
        }
        else if (isGrounded == false && gameObject.GetComponent<Flip>().facingRight == false && Input.GetAxis("Horizontal") < 0)
        {
            myRigidbody.velocity = new Vector2(horizontal * 1.0f, myRigidbody.velocity.y);
        }
        else 
        {
            myRigidbody.velocity = new Vector2(horizontal * 0.0f, myRigidbody.velocity.y);
        }

        if ((Input.GetAxis("Horizontal") > 0.0f || Input.GetAxis("Horizontal") < 0.0f) && manager.dragging == false && stop == false)
        {
            movementSpeed = 3.0f;
        }
        else if (Input.GetAxis("Horizontal") == 0.0f)
        {
            movementSpeed = 0.0f;
        }
        else if(manager.dragging == true)
        {
            movementSpeed = 1.5f;
        }
        else if(stop == true)
        {
            movementSpeed = 0.0f;
        }

        if (treePushing == true && Input.GetAxis("Horizontal") < 0.0f)
        {
            myRigidbody.velocity = new Vector2(horizontal * 0.01f, myRigidbody.velocity.y);
        }
        else if (treePushing == true && Input.GetAxis("Horizontal") > 0.0f)
        {
            myRigidbody.velocity = new Vector2(horizontal * 0.0f, myRigidbody.velocity.y);
        }

        // If the player should jump...
        /*if  (jump == true)
        {
            // Add a vertical force to the player.
            myRigidbody.AddForce(new Vector2(0f, jumpForce));
            animator.SetTrigger("Jump");
            movementSpeed = 1.5f;
            jump = false;
        }*/
    }

    // не работает
    private void HandleLayers()
    {
        if(nextLayer == false)
        {
            animator.SetLayerWeight(1, 1);
        }
        else if (nextLayer == true)
        {
            animator.SetLayerWeight(1, 0);
        }
    }
    /*private void HandleLayers()
    {
        if(!isGrounded && landed == false)
        {
            animator.SetLayerWeight(1, 1);
        }
        else if (landed == true)
        {
            animator.SetLayerWeight(1, 0);
        }
    }*/
}
