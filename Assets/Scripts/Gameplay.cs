using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : Game
{
    private void Start()
    {
        GameStart();
        StartCoroutine(ObstacleGeneration());
        StartCoroutine(CratersGeneration());   
    }

    private void FixedUpdate()
    {
        GameProcess();
    }
}
