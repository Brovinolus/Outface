using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CageTrigger : MonoBehaviour
{
    int i;
    public bool done = false;
    public GameObject cage;
    public GameObject forTrigger;
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject bug2;
    [SerializeField]
    private GameObject bug;
    [SerializeField]
    private GameObject player;
    [SerializeField] GameManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cage"))
        {
            GetComponent<AudioSource>().Play();
            cage.GetComponent<PushCage>().isPushingDone = true;
            cage.GetComponent<PushCage>().playerPos = false;
            cage.GetComponent<SpriteRenderer>().sortingOrder = 1;
            forTrigger.SetActive(false);
            ground.SetActive(true);
            done = true;
            StartCoroutine("GoDown");
        }
    }
    private void Update()
    {

        GoDown();
    }
    IEnumerator GoDown()
    {
        for (i = 0; i < 15; i++)
        {
            cage.transform.position -= new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(.01f);
        }
        if (manager.bugInCage == true)
        {
            bug2.SetActive(false);
            //Restart
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y);
        }
        cage.GetComponent<PushCage>().enabled = false;
        cage.GetComponent<PushCage>().openCageTrigger.SetActive(false);
        manager.cageInTheWater = true;
    }
}

