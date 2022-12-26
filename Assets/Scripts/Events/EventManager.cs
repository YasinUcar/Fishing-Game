using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action NextLevel;
    public static event Action NextFish;
    bool win;
    private void Update()
    {

    }
    public static void StartNextFish()
    {
        NextFish?.Invoke();
    }


}
