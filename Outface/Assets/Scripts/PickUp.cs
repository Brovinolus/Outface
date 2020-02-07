using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;

    //public GameObject itemButton;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameManager manager;
    [SerializeField] private LayerMask groundMask;
    float delayOn;
    public bool isOnTrigger;
    bool switcher;
    public ParticleSystem part;
    [SerializeField] bool thisOne;
    public bool triggerZone;
    public bool grounded;
    CircleCollider2D circleCollider2d;
    [SerializeField] GameObject background;
    public bool reset;
    bool setParent;
    public GameObject textPress;
    [SerializeField] GameObject hint;
    bool disableHint;
    private void Start()
    {
        circleCollider2d = gameObject.GetComponent<CircleCollider2D>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (manager.notHere == false && grounded == true)
        {
            var main = part.main;
            main.startColor = new Color(0, 1, 0, 1);
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, 1f);
        }
        else if(manager.notHere == true || grounded == false)
        {
            var main = part.main;
            main.startColor = new Color(1, 0, 0, 1);
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        if (IsGrounded())
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if(thisOne == false)
        {
            //transform.SetParent(background.transform);
        }

        if (thisOne == true)
        {
            if (manager.part == true && manager.dragging == true)
            {
                part.Play();
                part.GetComponent<ParticleSystemRenderer>().sortingOrder = 8;
            }
            else
            {
                part.Stop();
                part.GetComponent<ParticleSystemRenderer>().sortingOrder = 7;
            }
            if (manager.setActive == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                transform.parent = null;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                transform.SetParent(transform);
            }

            if (player.GetComponent<Movement>().movementSpeed == 0.0f)
            {
                player.GetComponent<Animator>().SetBool("Stop", true);
            }
            else
            {
                player.GetComponent<Animator>().SetBool("Stop", false);
            }
        }
            follow();
      
            if (isOnTrigger == true && Input.GetKeyDown("e") && switcher == false && manager.dragging == false )
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
                disableHint = true;
                hint.SetActive(false);
                if (gameObject.tag == "1")
                {
                    manager.flower1 = true;
                }
                if (gameObject.tag == "2")
                {
                    manager.flower2 = true;
                }
                if (gameObject.tag == "3")
                {
                    manager.flower3 = true;
                }
                if (gameObject.tag == "4")
                {
                    manager.flower4 = true;
                }
                if (gameObject.tag == "5")
                {
                    manager.flower5 = true;
                }
                if (gameObject.tag == "6")
                {
                    manager.flower6 = true;
                }
                if (gameObject.tag == "7")
                {
                    manager.flower7 = true;
                }

                player.GetComponent<Flowers>().reset = true;
                triggerZone = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                thisOne = true;
                part.Play();
                transform.SetParent(player.transform);
                gameObject.GetComponent<AudioSource>().Play();
                //player.GetComponent<Animator>().SetBool("isPushing", true);
                //player.GetComponent<SoundsOfMovement>().delay *= 2;
                manager.dragging = true;
                transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
                //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                switcher = true;
                isFollow = true;
            }
            else if (Input.GetKeyDown("e") && switcher == true && manager.notHere == false && player.GetComponent<Movement>().isGrounded == true && grounded == true)
            {
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 8;
                if (gameObject.tag == "1")
                {
                    manager.flower1 = false;
                }
                if (gameObject.tag == "2")
                {
                    manager.flower2 = false;
                }
                if (gameObject.tag == "3")
                {
                    manager.flower3 = false;
                }
                if (gameObject.tag == "4")
                {
                    manager.flower4 = false;
                }
                if (gameObject.tag == "5")
                {
                    manager.flower5 = false;
                }
                if (gameObject.tag == "6")
                {
                    manager.flower6 = false;
                }
                if (gameObject.tag == "7")
                {
                    manager.flower7 = false;
                }
                player.GetComponent<Flowers>().reset = false;
                thisOne = false;

                transform.SetParent(background.transform);
                //transform.SetParent(transform);
                gameObject.GetComponent<CircleCollider2D>().enabled = true;
                part.Stop();
                //player.GetComponent<Animator>().SetBool("isPushing", false);
                //player.GetComponent<SoundsOfMovement>().delay /= 2;
                manager.dragging = false;
                transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
                if (player.GetComponent<Flip>().facingRight == true)
                    transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z);
                if (player.GetComponent<Flip>().facingRight == false)
                    transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, player.transform.position.z);
                switcher = false;
                isFollow = false;
            }
    }

    bool isFollow;
    void follow()
    {
        if(isFollow == true && player.GetComponent<Flip>().facingRight == true)
        {
            transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
        }
        else if (isFollow == true && player.GetComponent<Flip>().facingRight == false)
        {
            transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && disableHint == false)
        {
            hint.SetActive(true);
        }
        if (other.CompareTag("Player") && manager.dragging == false)
        {
            textPress.GetComponent<Text>().text = "Press 'E' to pick up";
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
        if(other.CompareTag("ForPickUp"))
        {
            manager.notHere = true;
        }
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isOnTrigger = false;
        manager.notHere = false;
        grounded = false;
        textPress.GetComponent<Text>().text = "";
        hint.SetActive(false);
    }

    private bool IsGrounded()
    {
        float extraHeight = 1f;
        RaycastHit2D raycastHit2d = Physics2D.Raycast(circleCollider2d.bounds.center, Vector2.down, circleCollider2d.bounds.extents.y + extraHeight, groundMask);
        Color rayColor;
        if(raycastHit2d.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(circleCollider2d.bounds.center, Vector2.down * (circleCollider2d.bounds.extents.y + extraHeight), rayColor);
        return raycastHit2d.collider != null;
    }
    private void OnDestroy()
    {
        gameObject.GetComponent<AudioSource>().Play();
        //player.GetComponent<SoundsOfMovement>().delay /= 2;
    }
}
