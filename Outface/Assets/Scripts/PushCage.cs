using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushCage : MonoBehaviour
{
    public GameObject player;
    public GameManager manager;
    public bool playerPos;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myboxCollider2D;
    public GameObject textPress;
    //public GameObject forTrigger;
    public GameObject openCageTrigger;
    bool isPlayerInside;
    public bool isPushingDone;
    [SerializeField] GameObject hint;
    [SerializeField] GameObject bug;
    public bool pushNow;
    [SerializeField] SpriteRenderer press;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myboxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInside == true && player.GetComponent<Movement>().movementSpeed > 0.0f && turnOff == true)
        {
            if(gameObject.GetComponent<AudioSource>().isPlaying == false)
                gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
        Push();
        FollowPlayer();
    }

    void Push()
    {
        if (isPlayerInside == true && Input.GetKeyDown("f") && turnOff == false && player.GetComponent<Flip>().facingRight == true && pushNow == true)
        {
            manager.ready = false;
            player.GetComponent<Animator>().SetBool("isPushing", true);
            player.GetComponent<Movement>().nextJump = false;
            player.GetComponent<Flip>().enabled = false;
            openCageTrigger.transform.parent = transform;
            openCageTrigger.SetActive(false);
            manager.dragging = true;
            playerPos = true;
            turnOff = true;
            //forTrigger.SetActive(true);
        }

        else if (isPlayerInside == true && Input.GetKeyDown("f") && turnOff == true || isPushingDone == true)
        {
            manager.ready = true;
            player.GetComponent<Animator>().SetBool("isPushing", false);
            textPress.GetComponent<Text>().text = "";
            player.GetComponent<Movement>().nextJump = true;
            player.GetComponent<Flip>().enabled = true;
            openCageTrigger.transform.parent = null;
            openCageTrigger.SetActive(true);
            manager.dragging = false;
            playerPos = false;
            turnOff = false;
            //forTrigger.SetActive(false);
        }

        if (isPlayerInside == true && player.GetComponent<Flip>().facingRight == true && pushNow == true)
        {
            press.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && manager.dragging == false && gameObject.GetComponent<BugInCage>().enabled == true)
        { 
            isPlayerInside = true;
            textPress.GetComponent<Text>().text = "Press 'F' to push the cage";
        }

        if(other.CompareTag("Player") && manager.dragging == false && gameObject.GetComponent<BugInCage>().enabled == true && pushNow == false)
        {
             hint.SetActive(true);
        }
    }
    private bool turnOff;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(false);
            isPlayerInside = false;
            press.enabled = false;
        }
    }

    bool boundaries;
    private void FollowPlayer()
    {
        //работает если отключить исТригер в бокс колайдере и рижидбади
        if (playerPos == true)
        {
            transform.position = new Vector3(player.transform.position.x + 2.5f, transform.position.y, transform.position.z);

        }
        //boundaries
        if(player.transform.position.x <= -1.2f && playerPos == true)
        {
            //на прямую нельзя присваивать позицию х
            Vector3 posX = player.transform.position;
            //теперь можно получить присвоить позицию х и задать границу -1.2 и 3. Кламп будут возвращать заначение между этими числами
            posX.x = Mathf.Clamp(posX.x,  -1.2f, 3);
            //присваиваем полученное значение для позиции игрока, чтобы использовать эти границы
            player.transform.position = posX;
        }
    }
}
