using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Language.Manager
{
    [CreateAssetMenu(menuName = "Language/LanguageManager", fileName = "New LangManager Settings")]
    public class LanguageManagerSettings : ScriptableObject
    {
        [SerializeField] public List<LanguageSettings> _languageSettings;
        public string CurrentLang
        {
            get
            {
                return PlayerPrefs.GetString("CurrentLang" + name);
            }
            set
            {
                PlayerPrefs.SetString("CurrentLang" + name, value);
            }
        }
        
    }
}