using System;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent GameOverAction = new UnityEvent();
    public static UnityEvent ShipUpAction = new UnityEvent();
    public static UnityEvent ShipDownAction = new UnityEvent();

    public static void GameOver() 
    {
        GameOverAction.Invoke();
    }

    public static void ShipUp() 
    {
        ShipUpAction.Invoke();
    }

    public static void ShipDown()
    {
        ShipDownAction.Invoke();
    }

}
