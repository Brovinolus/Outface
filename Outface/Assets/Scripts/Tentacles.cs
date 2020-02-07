using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tentacles : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private GameObject key2;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject inventorySlot6;
    [SerializeField] GameObject bug2;
    [SerializeField] GameObject hint;
    public bool animationOff;
    bool isOnTriiger;

    private void Update()
    {
        if(isOnTriiger)
        {
            if (manager.flower6 == true)
            {
                hint.SetActive(true);
                text.GetComponent<Text>().text = "Press 'F' to touch the tentacles with the bug";
            }
            else if (manager.flower6 == false)
            {
                hint.SetActive(true);
                text.GetComponent<Text>().text = "You need to get this key somehow";
            }

            if (Input.GetKeyDown("f") && manager.flower6 == true)
            {
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Animator>().SetBool("Drop", true);
                hint.SetActive(false);
                key2.GetComponent<Key2>().enabled = true;
                key2.GetComponent<CircleCollider2D>().enabled = true;
                inventorySlot6.transform.parent = null;
                manager.dragging = false;
                Destroy(bug2);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            isOnTriiger = true;
        }
    }

    private void AnimationOff()
    {
        gameObject.GetComponent<Animator>().SetBool("Drop", false);
        animationOff = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnTriiger = false;
        hint.SetActive(false);
    }
}
