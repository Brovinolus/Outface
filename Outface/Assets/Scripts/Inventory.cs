using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject invenSetActive;
    bool turnOn;

    void Update()
    {
        if(Input.GetKeyDown("i") && turnOn == false)
        {
            invenSetActive.SetActive(true);
            turnOn = !turnOn;
        }
        else if (Input.GetKeyDown("i") && turnOn == true)
        {
            invenSetActive.SetActive(false);
            turnOn = !turnOn;
        }

    }
}
