using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterDown : MonoBehaviour
{
    int i;
    public bool done;
    public GameManager manager;
    public GameObject blood;
    public GameObject inventorySlot1;
    public GameObject textPress;
    public GameObject mushroom1;
    bool isOnPosition;
    [SerializeField] GameObject hint;
    [SerializeField] AudioSource sound;

    private void Update()
    {
        if(isOnPosition == true)
        {
            if (manager.flower1 == true)//done == false && manager.flower1 == true)
            {
                textPress.GetComponent<Text>().text = "Press 'F' to put the mushroom into the water";
            }
            else if (manager.flower1 == false)
            {
                textPress.GetComponent<Text>().text = "The water seems to be dangerous";
            }

            if (manager.flower1 == true && Input.GetKeyDown("f")) //&& done == false)
            {
                //gameObject.GetComponent<AudioSource>().Play();
                hint.SetActive(false);
                Destroy(mushroom1);
                manager.flower1 = false;
                manager.dragging = false;
                StartCoroutine("waterDown");
                blood.SetActive(true);
            }
        }
                
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOnPosition = true;
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hint.SetActive(false);
        if (other.CompareTag("Player"))
            isOnPosition = false;
    }

    IEnumerator waterDown()
    {
        for (i = 0; i < 5; i++)
        {
            transform.position += new Vector3(0, -0.1f, 0);
            blood.transform.position += new Vector3(0, -0.1f, 0);
            yield return new WaitForSeconds(.01f);
        }
        done = true;
        textPress.GetComponent<Text>().text = "";
        inventorySlot1.transform.parent = null;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        sound.GetComponent<AudioSource>().Play();
    }
}
