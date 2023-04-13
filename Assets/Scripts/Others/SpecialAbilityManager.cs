using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityManager : SpecialAbilities
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Button Button;
    private string[] ShipNames = { "CargoA(Clone)", "CargoB(Clone)", "Miner(Clone)", 
        "SpeederA(Clone)", "SpeederB(Clone)", "SpeederC(Clone)", "SpeederD(Clone)" };

    [SerializeField] private GameObject Shot;

    private void Start()
    {
        DataHolder.specialAbility = 5;
        StartCoroutine(SpecialAbilityStatus());
    }

    private void FindShip() 
    {
        Ship = GameObject.FindGameObjectWithTag("Ship");
        shipAnimator = Ship.GetComponent<Animator>();
    }

    public void UseSpecialAbility() 
    {
        FindShip();
        StartCoroutine(SliderMinus());  
        DataHolder.fuel = 30;
        
        for(int i = 0; i < ShipNames.Length; i++) 
        {
            if(ShipNames[i] == Ship.name) 
            {
                switch (i) 
                {
                    case 0:
                        SetTurboModeAbility();
                        break;
                    case 1:
                        SetTransparencyAbility();
                        break;
                    case 2:
                        SetShootingAbility(Shot);
                        break;
                    case 3:
                        SetProtectiveShieldAbility();
                        break;
                    case 4:
                        SetAutoPilotAbility();
                        break;
                    case 5:
                        SetRadarAbility();
                        break;
                    case 6:
                        SetXAbility();
                        break;
                }
            }
        }
    }

    private IEnumerator SpecialAbilityStatus() 
    {
        while (true) 
        {
            Slider.value = DataHolder.specialAbility;
            Button.gameObject.SetActive(DataHolder.specialAbility == 5 ? true : false);

            yield return null;
        }
    }

    private IEnumerator SliderMinus()
    {
        while (true)
        {
            if (DataHolder.specialAbility > 0)
            {
                DataHolder.specialAbility -= 0.05f;
            }
            else
            {
                DataHolder.specialAbility = 0;
                break;
            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
