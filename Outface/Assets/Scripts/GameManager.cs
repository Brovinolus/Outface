using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Parentobject;
    public GameObject[] AllObjects;
    public GameObject pickUp;
    public GameObject player;
    public GameObject menu;
    [SerializeField]
    ParticleSystem partSystem1;
    [SerializeField]
    ParticleSystem partSystem2;
    [SerializeField] GameObject cameraAudioListener;
    //public GameObject body;
    public bool flower1;
    public bool flower2;
    public bool flower3;
    public bool flower4;
    public bool flower5;
    public bool flower6;
    public bool flower7;
    public bool dragging;
    public bool bugInCage;
    public bool treeDown;
    //public bool notJumping;
    bool ok;
    public bool ready;
    public bool change;
    public bool part;
    public bool push;
    public bool setActive;
    public bool notHere;
    public bool forBug;
    public bool cageInTheWater;
    //public bool isOntrgger;

    private void Start()
    {
        //Time.timeScale = 0;
    }
    private void Update()
    {
        if(push == true)
        {
            player.GetComponent<Animator>().SetBool("isPushingTree", true);
        }
        if (dragging == true && part == true)
        {
            player.GetComponent<SoundsOfMovement>().delay = 0.4f;
            player.GetComponent<Animator>().SetBool("isPushing", true);
            //pickUp.GetComponent<PickUp>().part.Play();
        }
        else if (part == false || dragging == false)
        {
            player.GetComponent<Animator>().SetBool("isPushing", false);
            player.GetComponent<SoundsOfMovement>().delay = 0.2f;
            //pickUp.GetComponent<PickUp>().part.Stop();
        }

        if (dragging == true && b == true && change == false)
        {
            setActive = false;
            
            //pickUp.GetComponent<PickUp>().part.Stop();
        }
        else if (b == false || change == true)
        {
            setActive = true;
            //pickUp.GetComponent<PickUp>().part.Play();
        }
        
        if (ok == true)
        {
            
        }
    }
    void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        Menu();
        if (ready == true)
        {
            ok = true;
            RotateCanvas();
        }
        else
        {
            ok = false;
        }
    }

    int z = 0;
    public bool s;
    public bool newWorld = true;
    public bool b;
    [SerializeField]
    float speedRotation;

    private void RotateCanvas()
    {
        if (Input.GetKeyDown(KeyCode.V) && b == false && player.GetComponent<Movement>().movementSpeed == 0.0f)
        {
            cameraAudioListener.GetComponent<AudioListener>().enabled = true;
            part = false;
            change = false;
            player.GetComponent<SoundsOfMovement>().wait = false;
            gameObject.GetComponent<MusicManager>().done = false;
            newWorld = false;
            //notJumping = false;
            s = !s;
            b = true;
            player.SetActive(false);

            foreach (GameObject obj in AllObjects)
            {
                obj.transform.SetParent(Parentobject.transform);
            }   
            StartCoroutine("Rotating");
            partSystem1.Play();
            partSystem2.Play();
        }
    }

    public int i;
    int y = 0;
    IEnumerator Rotating()
    {
        Vector3 target = new Vector3(-0.48f, 0.0f, 0.0f);
        for (i = 0; i < (180/speedRotation); i++)
        {
            Parentobject.transform.RotateAround(target, Vector3.back, (1 * speedRotation));

            yield return null;
        }
    
        foreach (GameObject obj in AllObjects)
        {
            obj.transform.parent = null;
        }
        player.SetActive(true);
        i = 0;
        b = false;
        forBug =! forBug;
        newWorld = true;
        change = true;
        part = true;
        gameObject.GetComponent<MusicManager>().done = true;
        partSystem1.Stop();
        partSystem2.Stop();
        cameraAudioListener.GetComponent<AudioListener>().enabled = false;
    }
    bool switching;
    void Menu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && switching == false && b == false)
        {
            menu.SetActive(true);
            switching = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && switching == true)
        {
            menu.SetActive(false);
            switching = false;

        }
    }
}
