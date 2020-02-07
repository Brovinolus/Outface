using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugInCage : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField] GameObject player;
    public GameObject cageTrigger;
    public GameObject trigger;
    public GameObject bug2;
    [SerializeField]
    GameObject openCageTrigger;
    [SerializeField] GameObject hint;
    //GameObject forTrigger;
    int i;
    public bool destroyCageWithBug = true;

    void Update()
    {
        if(manager.bugInCage == true && manager.s == true && manager.forBug == true && destroyCageWithBug == true)
        {
            gameObject.GetComponent<PushCage>().enabled = false;
            trigger.SetActive(true);
            StartCoroutine("CageMove");
        }
    }
    IEnumerator CageMove()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        openCageTrigger.SetActive(false);
        hint.SetActive(true);
        if (cageTrigger.GetComponent<CageTrigger>().done == false)
        {
            for (i = 0; i < 10; i++)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.01f, gameObject.transform.position.y, gameObject.transform.position.z);
                yield return new WaitForSecondsRealtime(10);
            }
        }
        else if (cageTrigger.GetComponent<CageTrigger>().done == true)
        {
            hint.SetActive(false);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        manager.bugInCage = false;
        bug2.SetActive(false);
        //forTrigger.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;

        //Restart
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(y);
    }
}
