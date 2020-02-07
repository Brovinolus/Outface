using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    private Inventory inventory;

    public GameManager manager;

    public GameObject[] itemButton;

    public GameObject textPress;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        textPress.GetComponent<Text>().text = "Press E";
    }
    private void OnTriggerStay2D (Collider2D other)
    {
        
        if (other.CompareTag("1") )
        {
            
            if (inventory.isFull[0] == false && Input.GetKeyDown("e"))
            {
                inventory.isFull[0] = true;
                Instantiate(itemButton[0], inventory.slots[0].transform, false);
                manager.flower1 = true;
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("2"))
        {
            if (inventory.isFull[1] == false && Input.GetKeyDown("e"))
            {
                inventory.isFull[1] = true;
                Instantiate(itemButton[1], inventory.slots[1].transform, false);
                manager.flower2 = true;
                Destroy(other.gameObject);
            } 
        }

        if (other.CompareTag("3"))
        {
            if (inventory.isFull[2] == false && Input.GetKeyDown("e"))
            {
                inventory.isFull[2] = true;
                Instantiate(itemButton[2], inventory.slots[2].transform, false);
                manager.flower3 = true;
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("4"))
        {
            if (inventory.isFull[3] == false && Input.GetKeyDown("e"))
            {
                inventory.isFull[3] = true;
                Instantiate(itemButton[3], inventory.slots[3].transform, false);
                manager.flower4 = true;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        textPress.GetComponent<Text>().text = "";
    }

}
