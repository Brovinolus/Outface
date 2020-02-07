using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject inventorySlot7;
    [SerializeField] GameObject hint;
    public bool isOnTrigger;
    private void Update()
    {
        if (isOnTrigger == true)
        {
            hint.SetActive(true);
            //text.GetComponent<Text>().text = "You need to get the key first";

            if (Input.GetKeyDown("f") && manager.flower7 == true)
            {
                inventorySlot7.transform.parent = null;
                int y = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(y + 1);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.GetComponent<Text>().text = "";
        isOnTrigger = false;
        hint.SetActive(false);
    }
}

