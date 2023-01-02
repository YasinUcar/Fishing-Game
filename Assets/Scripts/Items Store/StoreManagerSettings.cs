using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Store.Manager
{
    [CreateAssetMenu(menuName = "Items/StoreManager", fileName = "New StoreManager Settings")]
    public class StoreManagerSettings : ScriptableObject
    {
        public string CurrentHad
        {
            get
            {
                return PlayerPrefs.GetString("CurrentHad" + name);
            }
            set
            {
                PlayerPrefs.SetString("CurrentHad" + name, value);
            }

        }
        public string CurrentRod
        {
            get
            {
                return PlayerPrefs.GetString("CurrentRod" + name);
            }
            set
            {
                PlayerPrefs.SetString("CurrentRod" + name, value);
            }
        }
    }
}