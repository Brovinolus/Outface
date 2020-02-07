using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bush : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private GameObject cage;
    [SerializeField]
    private GameObject inventorySlot4;
    public GameObject textPress;
    bool done;
    public GameObject mushroom2;
    [SerializeField] GameObject hint;
    bool isOnTrigerr;

    private void Update()
    {
        if(isOnTrigerr == true)
        {
            if ( done == false && manager.flower4 == true)
            {
                //textPress.GetComponent<Text>().text = "You can try to put the mushroom here.";
                hint.SetActive(true);
            }
            else if (manager.flower4 == false)
            {
                hint.SetActive(true);
                //textPress.GetComponent<Text>().text = "The bush is moving. You should be careful.";
            }
            if (manager.flower4 == true && Input.GetKeyDown("f") && done == false)
            {
                gameObject.GetComponent<Animator>().enabled = false;
                cage.GetComponent<BugInCage>().destroyCageWithBug = false;
                //cage.GetComponent<BugInCage>().enabled = false;
                inventorySlot4.transform.parent = null;
                //textPress.GetComponent<Text>().text = "The bush stopped moving";
                done = true;
                manager.dragging = false;
                Destroy(mushroom2);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            isOnTrigerr = true;  
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTrigerr = false;
        hint.SetActive(false);
        textPress.GetComponent<Text>().text = "";
    }
}
