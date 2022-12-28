using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Level.Manager
{
    [CreateAssetMenu(menuName = "Level/Level Manager", fileName = "Level Manager Settings")]
    public class LevelManagerSettings : ScriptableObject
    {
        public int LevelCount
        {
            get
            {
                return PlayerPrefs.GetInt("LevelCount" + name);
            }
            set
            {
                PlayerPrefs.SetInt("LevelCount" + name, value);
            }
        }
    }
}