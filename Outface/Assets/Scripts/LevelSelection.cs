using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject house;
    public GameObject level;
    public Animator transitionAnim;
    public void StartLevel()
    {
        Debug.Log("Not ready");
    }

    public void StartLevel_2()
    {
        StartCoroutine(LoadScene());
    }

IEnumerator LoadScene()
{
    transitionAnim.SetTrigger("end");
    yield return new WaitForSeconds(1.5f);
    SceneManager.LoadScene(2);
}
public void Back()
    {
        house.SetActive(false);
        level.SetActive(false);
        player.GetComponent<Player>().youCanMove = true;
    }
}
