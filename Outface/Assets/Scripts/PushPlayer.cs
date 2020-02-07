using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 100f));
        }
    }
}
