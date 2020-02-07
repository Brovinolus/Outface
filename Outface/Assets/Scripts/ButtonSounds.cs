using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    [SerializeField] AudioSource Source;
    // Update is called once per frame
    public void OnPointerEnter(PointerEventData ped)
    {
        if(Source.isPlaying == false)
        Source.Play();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (Source.isPlaying == false)
            Source.Play();
    }
}
