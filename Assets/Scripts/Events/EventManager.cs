using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action NextLevel;
    private void Update()
    {
        if (GameManager.Instance.LevelCompleted() == true)
        {
            NextLevel?.Invoke(); //? = not null
            //GameManager.Instance.LevelCompleted(false);
            
        }
    }


}
