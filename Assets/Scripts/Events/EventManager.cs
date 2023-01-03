using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action NextLevel;
    public static event Action NextFish;
    public static event Action StartGame;

    public static void StartNextFish()
    {
        NextFish?.Invoke();
    }
    public static void StartGameEvent()
    {
        StartGame?.Invoke();
    }

}
