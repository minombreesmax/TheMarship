using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveShield : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
