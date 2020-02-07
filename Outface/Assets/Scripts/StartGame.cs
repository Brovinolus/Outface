using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject music;
    public Animator transitionAnim;
    // Start is called before the first frame update

    public void NewLevel()
    {
        //int y = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
