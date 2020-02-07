using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    int i;
    bool done;
    public GameObject point;
    public GameObject textPress;
    public GameObject ground;
    [SerializeField]
    GameObject player;
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    GameObject timeCountdown;
    [SerializeField] GameObject hint;
    [SerializeField] GameObject hold;
    public bool doIt;
    public float wait;
    bool turnOff;
    bool onPosition;
    bool stopCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && done == false)
        {
            hint.SetActive(true);
            textPress.GetComponent<Text>().text = "Press 'F' to push the tree";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            onPosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onPosition = false;
            hint.SetActive(false);
        }
    }

    private void Update()
    {
        if (onPosition == true && Input.GetKeyDown("f") && done == false && player.GetComponent<Flip>().facingRight == false && turnOff == false)
        {
            hold.SetActive(true);
            hint.SetActive(false);
            player.transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z);
            manager.ready = false;
            turnOff = true;
            player.GetComponent<Movement>().nextJump = false;
            player.GetComponent<Flip>().enabled = false;
            doIt = true;
            stopCoroutine = false;
        }
        else if (Input.GetKeyDown("f") && turnOff == true)
        {
            hold.SetActive(false);
            timeCountdown.GetComponent<TextMesh>().text = "";
            manager.ready = true;
            turnOff = false;
            manager.dragging = false;
            player.GetComponent<Movement>().treePushing = false;
            player.GetComponent<Movement>().nextJump = true;
            player.GetComponent<Flip>().enabled = true;
            doIt = false;
            stopCoroutine = true;
        }
        if (doIt == true)
        {
            textPress.GetComponent<Text>().text = "Push the tree";
            manager.dragging = true;
            player.GetComponent<Movement>().treePushing = true;
            if (Input.GetAxis("Horizontal") < 0.0f)
            {
                StartCoroutine("Wait");
                doIt = false;
            }
        }
    }

    int y;
    int countdown;
    IEnumerator Wait()
    {
        for (y = 3; y >= 0; y--)
        {
            if (Input.GetAxis("Horizontal") < 0.0f)
            {
                //timeCountdown.GetComponent<TextMesh>().text = y.ToString();
            }
            else if ((Input.GetAxis("Horizontal") >= 0.0f))
            {
                StopCoroutine(Wait());
                y = 3;
                //timeCountdown.GetComponent<TextMesh>().text = y.ToString();
            }
            yield return new WaitForSeconds(wait);
            if(stopCoroutine == true)
            {
                yield break;
            }
            countdown = y;
        }
        if (countdown == 0)
        {
            //timeCountdown.GetComponent<TextMesh>().text = "";
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hold.SetActive(false);
            StartCoroutine("treeDown");
        }
    }

    IEnumerator treeDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
        manager.ready = true;
        ground.SetActive(true);
        player.GetComponent<Movement>().nextJump = true;
        player.GetComponent<Flip>().enabled = true;
        player.GetComponent<Movement>().treePushing = false;
        manager.dragging = false;
        Vector3 target = new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z);
        for (i = 0; i < 45; i++)
        {
            transform.RotateAround(target, Vector3.forward, 2);
            yield return new WaitForSeconds(.01f);
        }
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        done = true;
        textPress.GetComponent<Text>().text = "";
        manager.treeDown = true;
        player.GetComponent<Movement>().nextJump = true;
        player.GetComponent<Flip>().enabled = true;
        player.GetComponent<Movement>().treePushing = false;
        manager.dragging = false;
    }
}
