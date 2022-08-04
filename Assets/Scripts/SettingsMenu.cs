using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider VolumeSlider, VibrationSlider;
    public Text VibrationText;

    private void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        VibrationSlider.value = PlayerPrefs.GetInt("Vibration");
    }

    private void SetVolume() 
    {
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
    }
    private void SetVibration() 
    {
        int vibrationStatus = (int)VibrationSlider.value;
        VibrationText.text = vibrationStatus == 1 ? "ON" : "OFF";
        PlayerPrefs.SetInt("Vibration", vibrationStatus);
    }
    
    private void FixedUpdate()
    {
        SetVolume();
        SetVibration();
    }
}
