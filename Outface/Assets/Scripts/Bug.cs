using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bug : MonoBehaviour
{
    bool done;
    public GameObject Bug2;
    public GameObject textPress;
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    GameObject openCage;
    [SerializeField] GameObject hint;
    bool isOnTrigger;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cage;
    public bool push;

    private void Update()
    {
        if (isOnTrigger == true && Input.GetKeyDown("f") && done == false)
        {
            cage.GetComponent<PushCage>().pushNow = true;
            player.GetComponent<Movement>().stop = true;
            hint.SetActive(false);
            manager.ready = false;
            if(manager.cageInTheWater == false)
            {
                Bug2.GetComponent<SpriteRenderer>().enabled = true;
                openCage.GetComponent<BoxCollider2D>().enabled = true;
            }
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            done = true;
            //textPress.GetComponent<Text>().text = "";
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && done == false)
        {
            isOnTrigger = true;
            hint.SetActive(true);
            textPress.GetComponent<Text>().text = "Press 'F' to push the bug";
        }
        if (other.CompareTag("Ground"))
        {
            //textPress.GetComponent<Text>().text = "You should follow it";
            StartCoroutine("Timer");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        textPress.GetComponent<Text>().text = "";
        isOnTrigger = false;
        hint.SetActive(false);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        textPress.GetComponent<Text>().text = "";
        gameObject.SetActive(false);
        manager.bugInCage = true;
        manager.ready = true;
        player.GetComponent<Movement>().stop = false;
    }
}
