using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameManager manager;
    private void OnEnable()
    {
        manager.b = true;
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        manager.b = false;
        Time.timeScale = 1;
    }
}
