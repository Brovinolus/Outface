using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] GameObject houseObject;
    [SerializeField] GameObject levelObject;
    [SerializeField] GameObject press;
    int current = 0;
    //float rotSpeed;
    [SerializeField] float speed;
    float WPradius = 1;
    bool goRight;
    bool goLeft;
    bool house = true;
    bool level;
    bool timeToActivate;
    public bool youCanMove = true;
    [SerializeField] GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
        //go right
        //может пропустить гейм обжект иначе из-за того что радиус равен нулю у него
        if (Vector3.Distance(wayPoints[current].transform.position, transform.position) < WPradius && goRight == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            current++;
            if(current == wayPoints.Length - 1)
            {
                goRight = false;
                level = true;
            }
        }

        //go left
        if (Vector3.Distance(wayPoints[current].transform.position, transform.position) < WPradius && goLeft == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            current--;
            if (current <= 0)
            {
                goLeft = false;
                house = true;
            }
        }

        //Input
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && current != wayPoints.Length && goLeft == false && youCanMove == true && house == true)
        {
            goRight = true;
            house = false;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && current != 0 && goRight == false && youCanMove == true && level == true)
        {
            goLeft = true;
            level = false;
        }

        //move
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current].transform.position, Time.deltaTime * speed);

        //stop animation
        if (transform.position == wayPoints[current].transform.position && goRight == false && goLeft == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            timeToActivate = true;
        }
        else
        {
            timeToActivate = false;
            press.SetActive(false);
        }
        Selection();
    }

    void Selection()
    {
        if (timeToActivate == true)
        {
            if(house == true || level == true)
            {
                press.SetActive(true);
            }
            if (house == true && Input.GetKeyDown(KeyCode.F))
            {
                houseObject.SetActive(true);
                youCanMove = false;
            }

            if (level == true && Input.GetKeyDown(KeyCode.F))
            {
                levelObject.SetActive(true);
                youCanMove = false;
            }
        }
    }
}

/*
 void Selection()
    {
        if (timeToActivate == true)
        {
            if (house == true && Input.GetKeyDown(KeyCode.F))
            {
                houseObject.SetActive(true);
                youCanMove = false;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                houseObject.SetActive(false);
                youCanMove = true;
            }

            if (level == true && Input.GetKeyDown(KeyCode.F))
            {
                levelObject.SetActive(true);
                youCanMove = false;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                levelObject.SetActive(false);
                youCanMove = true;
            }
        }
    }
 */
