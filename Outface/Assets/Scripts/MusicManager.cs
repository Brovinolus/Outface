using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    GameManager manager;
    bool startAudio1 = true;
    bool startAudio2;
    [SerializeField]
    AudioSource audio1;
    [SerializeField]
    AudioSource audio2;
    [SerializeField]
    AudioSource audio3;
    [SerializeField]
    float wait;
    [SerializeField]
    float crossFade1;
    [SerializeField]
    float crossFade2;
    [SerializeField]
    float targetVolume1;
    [SerializeField]
    float targetVolume2;
    bool s;
    bool isFading;
    bool finished;
    bool finished1 = true;
    public bool done = true;

    private void Start()
    {
        StartCoroutine(AudioVolumeUp1());
    }
    void Update()
    {
        if (manager.s == true && s == false && finished == true)
        {
            s = true;
            finished = false;
            finished1 = true;
            audio3.Play();
            StartCoroutine(AudioVolumeDown2());
            Debug.Log("+");
        }
        else if (manager.s == false && s == true && finished == true)
        {
            s = false;
            finished = false;
            finished1 = true;
            audio3.Play();
            StartCoroutine(AudioVolumeDown1());
            Debug.Log("-");
        }
        
        if(done == true && s == false && finished1 == true)
        {
            StartCoroutine(AudioVolumeUp1());
        }
        else if (done == true && s == true && finished1 == true)
        {
            StartCoroutine(AudioVolumeUp2());
        }
    }

    /*IEnumerator AudioVolumeUp1()
    {
        float startVolume = 0.01f;
        audio1.Play();
        while (audio1.volume < targetVolume1 || audio2.volume > 0)
        {
            audio2.volume -= startVolume * Time.deltaTime / crossFade;
            audio1.volume += startVolume * Time.deltaTime / crossFade;
            yield return new WaitForSeconds(wait);
        }
        audio2.Stop();
        finished = true;
        Debug.Log("1");
    }*/

    /*IEnumerator AudioVolumeUp2()
    {
        float startVolume = 0.01f;
        audio2.Play();
        while (audio2.volume < targetVolume1 || audio1.volume > 0)
        {
            audio1.volume -= startVolume * Time.deltaTime / crossFade;
            audio2.volume += startVolume * Time.deltaTime / crossFade;
            yield return new WaitForSeconds(wait);
        }
        audio1.Stop();
        finished = true;
        Debug.Log("1");
    }*/

    IEnumerator AudioVolumeUp1()
    {
        float startVolume = 0.1f;
        if (done == true)
        { 
            audio1.Play();
        while (audio1.volume < targetVolume1)
        {
            audio1.volume += startVolume * Time.deltaTime / crossFade1;
            yield return new WaitForSeconds(wait);
        }
        }
        finished = true;
        Debug.Log("1");
        finished1 = false;
    }

    IEnumerator AudioVolumeDown1()
    {
        float startVolume = 0.1f;
        while (audio2.volume > 0)
        {
            audio2.volume -= startVolume * Time.deltaTime / crossFade2;
            yield return new WaitForSeconds(wait);
        }
        audio2.Stop();
    }

    IEnumerator AudioVolumeUp2()
    {
        float startVolume = 0.1f;
        audio2.Play();
        while (audio2.volume < targetVolume2)
        {
            audio2.volume += startVolume * Time.deltaTime / crossFade2;
            yield return new WaitForSeconds(wait);
        }
        finished = true;
        Debug.Log("2");
        finished1 = false;
    }

    IEnumerator AudioVolumeDown2()
    {
        float startVolume = 0.1f;
        while (audio1.volume > 0)
        {
            audio1.volume -= startVolume * Time.deltaTime / crossFade1;
            yield return new WaitForSeconds(wait);
        }
        audio1.Stop();
    }
}
    //&& audio2.isPlaying == false
    /*
     
     IEnumerator AudioVolumeUp1()
    {
        float startVolume = 0.01f;
        audio1.Play();
        while (audio1.volume < targetVolume1 || audio2.volume > 0)
        {
            audio2.volume -= startVolume * Time.deltaTime / crossFade;
            audio1.volume += startVolume * Time.deltaTime / crossFade;
            yield return new WaitForSeconds(wait);
        }
        audio2.Stop();
        finished = true;
        Debug.Log("1");
    }

    ******************************************************************
    
       IEnumerator AudioVolumeUp1()
    {
            float startVolume2 = audio2.volume;
            while (audio2.volume > 0)
            {
                audio2.volume -= startVolume2 * Time.deltaTime / 1f;
                //Debug.Log(audio1.volume);
                yield return new WaitForSeconds(wait);
            }
            audio2.Stop();
            startVolume2 = audio2.volume;
            Debug.Log("1");

            ////////////////////

            audio1.Play();
            float startVolume1 = audio1.volume + 0.1f;
            while (audio1.volume < 1.00f)
            {
                audio1.volume += startVolume1 * Time.deltaTime / 1f;
                //Debug.Log(audio1.volume);
                yield return new WaitForSeconds(wait);
            }
            startVolume1 = audio1.volume;
            Debug.Log("port");
            finished = true;
    }

    IEnumerator AudioVolumeUp2()
    {
            float startVolume1 = audio1.volume;
            while (audio1.volume > 0)
            {
                audio1.volume -= startVolume1 * Time.deltaTime / 1f;
                //Debug.Log(audio1.volume);
                yield return new WaitForSeconds(wait);
            }
            audio1.Stop();
            startVolume1 = audio1.volume;
            Debug.Log("2");

            ////////////////////

            audio2.Play();
            float startVolume2 = audio2.volume + 0.1f;
            while (audio2.volume < 1.00f)
            {
                audio2.volume += startVolume2 * Time.deltaTime / 1f;
                //Debug.Log(audio1.volume);
                yield return new WaitForSeconds(wait);
            }
            startVolume2 = audio2.volume;
            Debug.Log("port2");
            finished = true;
    }
     */

