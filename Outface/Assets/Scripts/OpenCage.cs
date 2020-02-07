using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCage : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private GameObject bug2;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject inventorySlot3;
    bool done = false;
    public GameObject key1;
    [SerializeField] bool isOnTrigger;
    [SerializeField] GameObject background;
    [SerializeField] SpriteRenderer press;

    private void Update()
    {
        if(isOnTrigger == true)
        {
            if (manager.flower3 == true && Input.GetKeyDown("f") && done == false && manager.bugInCage == true && manager.dragging == true)
            {
                gameObject.GetComponent<AudioSource>().Play();
                bug2.GetComponent<CircleCollider2D>().enabled = true;
                bug2.GetComponent<SpriteRenderer>().sortingOrder = 7;
                text.GetComponent<Text>().text = "You've opened the cage";
                bug2.transform.SetParent(background.transform);
                inventorySlot3.transform.parent = null;
                manager.dragging = false;
                bug2.GetComponent<PickUp>().enabled = true;
                done = true;
                manager.bugInCage = false;
                manager.flower3 = false;
                Destroy(key1);
            }

            if (manager.flower3 == true && done == false && manager.bugInCage == true && manager.dragging == true)
            {
                press.enabled = true;
            }

            if (done == false && manager.flower3 == false && manager.bugInCage == true)
            {
                isOnTrigger = true;
                text.GetComponent<Text>().text = "You need to get the key to open the cage";
            }
            else if (done == false && manager.flower3 == true && manager.bugInCage == true)
            {
                text.GetComponent<Text>().text = "Press 'F' to open the cage";
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isOnTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            press.enabled = false;
            isOnTrigger = false;
        }
    }
}
