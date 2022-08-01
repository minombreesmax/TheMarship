using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCrystalsMenu : MonoBehaviour
{
    private AudioSource ErrorAudio;

    private void Start()
    {
        ErrorAudio = GetComponent<AudioSource>();
        ErrorAudio.Play();
    }

    public void SetMenuOff()
    {
        gameObject.SetActive(false);
    }

}
