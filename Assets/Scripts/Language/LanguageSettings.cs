using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Language.Manager
{
    [CreateAssetMenu(menuName = "Language/LanguageSettings", fileName = "New Lang(English-Turkish vb.) Settings")]
    public class LanguageSettings : ScriptableObject
    {
        [SerializeField] private string _langName;
        public string LangName { get => _langName; }

        [Header("UI")]
        [SerializeField] private string _settingsText;
        public string SettingsText { get => _settingsText; }
        [SerializeField] private string _langText;
        public string LangText { get => _langText; }
        [SerializeField] private string taptoStart;
        public string TapToStart { get => taptoStart; }
        [SerializeField] private string _characterButtonText;
        public string ChacterButtonText { get => _characterButtonText; }
        [SerializeField] private string _rodButtonText;
        public string RodButtonText { get => _rodButtonText; }
        public bool Unlock
        {
            get
            {
                return PlayerPrefs.GetInt("UnlockTrick" + name) == 1 ? true : false;
            }
            set
            {
                PlayerPrefs.SetInt("UnlockTrick" + name, value == true ? 1 : 0);
            }
        }
    }
}