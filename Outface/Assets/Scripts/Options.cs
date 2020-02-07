using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject controls;
    public void Audio()
    {

    }

    public void Controls()
    {
        controls.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
