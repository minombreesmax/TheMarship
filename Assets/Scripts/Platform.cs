using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public GameObject Ship, Checkmark, Lock, MissCrystalsMenu;
    public Camera mainCamera;
    public Text shipName, crystals, missCrystals;
    public int index, necessaryRecord, price;
    public Button buttonUse;
    public Canvas canvas;
    public AudioSource SelectSound, BuySound;
    private Rigidbody shipRigidbody;
    private float rotationY;
    
    private void Start()
    {
        shipRigidbody = Ship.GetComponent<Rigidbody>();
        rotationY = 180;
        
        if(PlayerPrefs.HasKey($"Ship{index}_status"))
        {
            necessaryRecord = PlayerPrefs.GetInt($"Ship{index}_status");
        }
    }

    public void ShipRotation()
    {
        rotationY++;
        shipRigidbody.transform.rotation = Quaternion.Euler(0, rotationY, 0);
        shipName.text = Ship.name;
    }

    public void ShipSelect()
    {
        SelectSound.Play();

        switch(mainCamera.transform.position.x)
        {
            case -70:
                PlayerPrefs.SetInt("shipNumber", 0);
                break;
            case -50:
                PlayerPrefs.SetInt("shipNumber", 1);
                break;
            case -30:
                PlayerPrefs.SetInt("shipNumber", 2);
                break;
            case -10:
                PlayerPrefs.SetInt("shipNumber", 3);
                break;
            case 10:
                PlayerPrefs.SetInt("shipNumber", 4);
                break;
            case 30:
                PlayerPrefs.SetInt("shipNumber", 5);
                break;
            case 50:
                PlayerPrefs.SetInt("shipNumber", 6);
                break;
        }
    }

    public void ShipBuy()
    {
        if(PlayerPrefs.GetInt("Crystals") >= price)
        {
            BuySound.Play();
            necessaryRecord = 0;
            int Crystals = PlayerPrefs.GetInt("Crystals") - price;
            PlayerPrefs.SetInt("Crystals", Crystals);
            PlayerPrefs.SetInt($"Ship{index}_status", necessaryRecord);
            crystals.text = $"{Crystals}";
        }
        else 
        {
            MissCrystalsMenu.SetActive(true);
            missCrystals.text = $"To buy you need another {price - PlayerPrefs.GetInt("Crystals")} crystals";
        }
    }

    public void ShipShow() 
    {
        if(mainCamera.transform.position.x == transform.position.x)
        {
            shipRigidbody.transform.position = new Vector3(Ship.transform.position.x, 10f, 2.5f);
            ShipRotation();
            canvas.gameObject.SetActive(true);
        }
        else
        {
            shipRigidbody.transform.position = new Vector3(Ship.transform.position.x, 6f, 2.5f);
            rotationY = 180;
            shipRigidbody.transform.rotation = Quaternion.Euler(0, rotationY, 0);
            canvas.gameObject.SetActive(false);
        }

        Checkmark.gameObject.SetActive(PlayerPrefs.GetInt("shipNumber") == index? true : false);
        Lock.gameObject.SetActive(PlayerPrefs.GetInt("Best") < necessaryRecord && !MissCrystalsMenu.activeInHierarchy ? true : false);
        buttonUse.gameObject.SetActive(PlayerPrefs.GetInt("shipNumber") != index? PlayerPrefs.GetInt("Best") > necessaryRecord? true : false : false);
    }

    private void FixedUpdate()
    {
        ShipShow();
    }
}