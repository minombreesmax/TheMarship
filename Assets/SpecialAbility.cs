using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbility : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Button Button;

    private void Start()
    {
        DataHolder.specialAbility = 0;
        StartCoroutine(SpecialAbilityStatus());
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
}
