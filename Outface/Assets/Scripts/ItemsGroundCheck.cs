using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGroundCheck : MonoBehaviour
{
    [SerializeField] GameObject pickUpItem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            pickUpItem.GetComponent<PickUp>().grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            pickUpItem.GetComponent<PickUp>().grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            pickUpItem.GetComponent<PickUp>().grounded = false;
        }
    }
}
