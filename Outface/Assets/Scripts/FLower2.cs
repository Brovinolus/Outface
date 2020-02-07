using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FLower2 : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject inventorySlot5;
    public GameObject flower5;
    bool done;
    [SerializeField] GameObject hint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && manager.flower5 == false && done == false)
        {
            hint.SetActive(true);
            text.GetComponent<Text>().text = "This flower is poisoned";
        }
        else if (collision.CompareTag("Player") && manager.flower5 == true && done == false)
        {
            hint.SetActive(true);
            text.GetComponent<Text>().text = "Press 'F' to touch it with the flower";
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && manager.flower5 == true && Input.GetKeyDown("f"))
        {
            hint.SetActive(false);
            text.GetComponent<Text>().text = "It's safe now";
            inventorySlot5.transform.parent = null;
            ground.SetActive(true);
            manager.dragging = false;
            manager.flower5 = false;
            done = true;
            Destroy(flower5);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hint.SetActive(false);
    }
}
