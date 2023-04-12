using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilities : MonoBehaviour
{
    [SerializeField] private Button Up, Down, Pause;
    protected GameObject Ship;
    protected Animator shipAnimator;

    private GameObject CargoB, CargoBT;

    protected void SetTurboModeAbility()
    {
        StartCoroutine(TurboMode());
    }

    protected void SetTransparencyAbility()
    {
        StartCoroutine("Transparency");
    }

    protected void SetShootingAbility()
    {
        print("ShootingAbility");
    }

    protected void SetProtectiveShieldAbility()
    {
        print("ProtectiveShieldAbility");
    }

    protected void SetAutoPilotAbility()
    {
        print("AutoPilotAbility");
    }

    protected void SetRadarAbility()
    {
        print("RadarAbility");
    }

    protected void SetXAbility()
    {
        print("XAbility");
    }

    private void SetButtonStatus(bool status)
    {
        Up.interactable = status;
        Down.interactable = status;
        Pause.interactable = status;
    }

    private void GetShipChild() 
    {
        if (Ship.name == "CargoB(Clone)") 
        {
            CargoB = Ship.transform.GetChild(0).gameObject;
            CargoBT = Ship.transform.GetChild(1).gameObject;
        }
    }

    private void SetShipChildStatus(bool status) 
    {
        CargoB.SetActive(!status);
        CargoBT.SetActive(status);
    }

    private IEnumerator TurboMode() 
    {
        SetButtonStatus(false);
        shipAnimator.Play("TurboModeUp");
        Time.timeScale = 2f;
        yield return new WaitForSecondsRealtime(10);
        Time.timeScale = 1f;
        shipAnimator.Play("TurboModeDown");
        SetButtonStatus(true);
    }

    private IEnumerator Transparency() 
    {
        GetShipChild();
        SetShipChildStatus(true);
        yield return new WaitForSecondsRealtime(10);
        SetShipChildStatus(false);
    }
}
