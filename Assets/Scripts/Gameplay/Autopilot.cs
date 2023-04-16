using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Autopilot : MonoBehaviour
{
    private RaycastHit hit;
    private Ray frontRay, upRay, downRay;
    private Vector3 upRayPosition, downRayPosition;

    private void OnEnable()
    {
        CreateRays();
        StartCoroutine(ShipAutoPilot());
    }

    private void CreateRays() 
    {
        frontRay = new Ray(transform.position, transform.forward);

        upRayPosition = new Vector3(-30, transform.position.y + 3f, transform.position.z);
        upRay = new Ray(upRayPosition, transform.forward);

        downRayPosition = new Vector3(-30, transform.position.y - 7f, transform.position.z);
        downRay = new Ray(downRayPosition, transform.forward);
    }

    private IEnumerator ShipAutoPilot() 
    {
        while (true) 
        {
            if (Physics.Raycast(downRay, out hit))
            {
                var hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Barrel" && hit.distance < 15)
                    GlobalEventManager.ShipDown();
            }

            if (Physics.Raycast(upRay, out hit))
            {
                var hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Meteor" && hit.distance < 15)
                    GlobalEventManager.ShipDown();
            }

            if (Physics.Raycast(frontRay, out hit))
            {
                var hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Rock" && hit.distance < 25)
                    GlobalEventManager.ShipUp();
            }

            if (enabled == false)
                break;

            yield return null;
        }
    }
}
