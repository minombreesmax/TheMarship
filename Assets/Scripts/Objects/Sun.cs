using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float posX;

    private void Start()
    {
        posX = PlayerPrefs.HasKey("posX")? PlayerPrefs.GetFloat("posX") : transform.position.x;
        StartCoroutine(SunCorutine());
    }

    private IEnumerator SunCorutine() 
    {
        while (true)
        {
            posX = posX > -110 ? posX -= 0.01f : 110;
            transform.position = new Vector3(posX, 35, 130);
            PlayerPrefs.SetFloat("posX", posX);
            yield return null;
        }
    }
}
