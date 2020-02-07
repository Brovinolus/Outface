using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewSelection : MonoBehaviour
{
    public bool firstSelection;
    GameObject lastSelect;
    [SerializeField] GameObject newSelection;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (firstSelection == false)
        {
            EventSystem.current.SetSelectedGameObject(newSelection);
            firstSelection = true;
        }
    }
    private void OnDisable()
    {
        firstSelection = false;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
/*
 if (EventSystem.current.currentSelectedGameObject != newSelection && firstSelection == false)
        {
            EventSystem.current.SetSelectedGameObject(newSelection);
        }
        else if (EventSystem.current.currentSelectedGameObject == newSelection)
        {
            firstSelection = true;
        }
 */
