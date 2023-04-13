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
    private GameObject[] Gun = new GameObject[2];
    private GameObject Shield;

    protected void SetTurboModeAbility()
    {
        StartCoroutine(TurboMode());
    }

    protected void SetTransparencyAbility()
    {
        StartCoroutine(Transparency());
    }

    protected void SetShootingAbility(GameObject shot)
    {
        GetShipGun();
        StartCoroutine(Shooting(shot, Gun));
    }

    protected void SetProtectiveShieldAbility()
    {
        GetShipShield();
        Shield.SetActive(true);
        Ship.tag = "Shield";
        DataHolder.specialAbility = 0;
    }
    
    #region abilities
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
    #endregion

    private void SetButtonStatus(bool status)
    {
        Up.interactable = status;
        Down.interactable = status;
        Pause.interactable = status;
    }

    private void SetShipChildStatus(bool status) 
    {
        CargoB.SetActive(!status);
        CargoBT.SetActive(status);
    }
    
    private void GetShipChild() 
    {
        if (Ship.name == "CargoB(Clone)") 
        {
            CargoB = Ship.transform.GetChild(0).gameObject;
            CargoBT = Ship.transform.GetChild(1).gameObject;
        }
    }
    
    private void GetShipGun() 
    {
        if(Ship.name == "Miner(Clone)") 
        {
            var mainGun = Ship.transform.GetChild(0).gameObject;
            Gun[0] = mainGun.transform.GetChild(0).gameObject;
            Gun[1] = mainGun.transform.GetChild(1).gameObject;

            foreach (var gun in Gun)
            {
                float x = gun.transform.position.x + 0.1f;
                gun.transform.position = new Vector2(x, gun.transform.position.y);
            }
        }
    }

    private void GetShipShield() 
    {
        if (Ship.name == "SpeederA(Clone)")
            Shield = Ship.transform.GetChild(0).gameObject;
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

    private IEnumerator Shooting(GameObject shot, GameObject[] gun) 
    {
        while (true)
        {
            Instantiate(shot, gun[0].transform.position, Quaternion.Euler(90, 90, 0));
            yield return new WaitForSeconds(1);
            Instantiate(shot, gun[1].transform.position, Quaternion.Euler(90, 90, 0));

            if (DataHolder.specialAbility <= 0)
                break;
        }
    }

}
