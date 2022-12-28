using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.Manager
{
    [CreateAssetMenu(menuName = "Settings", fileName = "Settings Manager")]
    public class SettingsManagerSettings : ScriptableObject
    {
        public bool AudioMute
        {
            get
            {
                return PlayerPrefs.GetInt("AudioMute" + name) == 1 ? true : false;
            }
            set
            {
                PlayerPrefs.SetInt("AudioMute" + name, value == true ? 1 : 0);
            }
        }
       
    }
}