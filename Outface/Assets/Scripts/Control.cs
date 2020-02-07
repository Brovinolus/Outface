using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public int selectedButton = 0;
    public Image[] buttonList;
    public GameObject[] arrows;

    private void Start()
    {
        buttonList = GetComponentsInChildren<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //MoveToUp();
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //MoveToDown();
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            BroadcastMessage(buttonList[selectedButton].name + "Action");
        }
    }
}
