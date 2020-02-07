using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPickUp : MonoBehaviour
{
    [SerializeField] GameManager manager;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(manager.dragging == true)
        {
            Debug.Log("Hit");
            manager.notHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (manager.dragging == true)
        {
            manager.notHere = false;
        }
    }
}
