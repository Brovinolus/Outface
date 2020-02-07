using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageContoller : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private HealthController healthContoller;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject ground;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine("Damage");
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Animator>().SetFloat("Speed", 0);
            ground.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
    private void Update()
    {
        Damage(); 
    }
    IEnumerator Damage()
    {
        healthContoller.playerHealth = healthContoller.playerHealth - damage;
        healthContoller.UpdateHealth();
        player.transform.position -= new Vector3(0, 0.3f, 0);
        yield return new WaitForSeconds(1f);
    }
}
