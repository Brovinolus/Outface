using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flowers : MonoBehaviour
{
    private Inventory inventory;

    public GameManager manager;

    public GameObject[] itemButton;

    public GameObject textPress;

    public bool reset;
    public bool one;
    public bool two;
    public bool three;
    public bool four;
    public bool five;
    public bool six;
    public bool seven;
    GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
    }
    /*   if(inventory.isFull[0] == false && reset == true && one == true)
        {
            inventory.isFull[0] = true;
            instance = Instantiate(itemButton[0], inventory.slots[0].transform, false);
            manager.flower1 = true;
        }
        else if(inventory.isFull[0] == true && reset == false)
        {
            manager.flower1 = false;
            inventory.isFull[0] = false;
            Destroy(instance);
        }*/
    private void Update()
    {
        if(manager.flower1 == true)
        {
            inventory.isFull[0] = true;
            //inventory.slots[0].GetComponent<Image>().color = new Color32(1, 1, 1, 1);
            //instance = Instantiate(itemButton[0], inventory.slots[0].transform, false);
        }
        else if(manager.flower1 == false)
        {
            inventory.isFull[0] = false;
            Destroy(instance);
        }

        if (manager.flower2 == true)
        {
            inventory.isFull[1] = true;
            Instantiate(itemButton[1], inventory.slots[1].transform, false);
        }
        else if (manager.flower2 == false)
        {
            inventory.isFull[1] = false;
            Destroy(instance);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
