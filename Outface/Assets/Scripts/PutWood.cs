using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutWood : MonoBehaviour
{
    int i;
    bool done;
    public GameManager manager;
    public GameObject putTree;
    public GameObject inventorySlot2;
    public GameObject textPress;
    public GameObject treeStump;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && done == false && manager.flower2 == true)
        {
            textPress.GetComponent<Text>().text = "Press 'F' to put the stump";
        }
        else if(other.CompareTag("Player") && manager.flower2 == false)
        {
            textPress.GetComponent<Text>().text = "You don't have the stump";
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && manager.flower2 == true && Input.GetKeyDown("f") && done == false)
        {
            putTree.SetActive(true);
            done = true;
            inventorySlot2.transform.parent = null;
            textPress.GetComponent<Text>().text = "";
        }
    }
}
