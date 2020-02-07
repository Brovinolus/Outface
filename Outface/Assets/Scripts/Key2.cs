using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key2 : MonoBehaviour
{
    
    [SerializeField]
    private GameManager manager;
    [SerializeField] GameObject key;
    [SerializeField] float delay;
    [SerializeField] AudioSource drop;
    public Sprite sprite;
    void Update()
    {
        if (key.GetComponent<Tentacles>().animationOff == true)
        {
            key.GetComponent<Tentacles>().animationOff = false;
            gameObject.GetComponent<Animator>().enabled = true;
            StartCoroutine(KeyDown());
        }
    }

    IEnumerator KeyDown()
    {
        for (int i = 0; i <= 3; i++)
        {
            Vector3 PosY = transform.position;
            PosY.y -= 0.4f;
            transform.position = PosY;
            yield return new WaitForSeconds(delay);
        }
        drop.Play();
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        if (manager.treeDown == false)
        {
            Destroy(gameObject);
            //Restart
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y);
        }
    }
}  
