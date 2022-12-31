using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Language.Manager
{

    public class LanguageManager : MonoBehaviour
    {
        [SerializeField] private GameObject _copyObject;
        [SerializeField] private Transform _itemContent;
        [SerializeField] private LanguageManagerSettings _languageManagerSettings;

        private GameObject _objNewItem;
        [SerializeField]
        private TextMeshProUGUI _settingsEng, _langTextEng, taptoStartEng,
        _settingsTurkish, _langTextTurkish, taptoStartTurkish;

        private void Start()
        {
            OnStart();
            ChangeTexts(_languageManagerSettings.CurrentLang);
        }
        private void OnStart()
        {
            // foreach (var item in _languageManagerSettings)
            // {
            //     _objNewItem = Instantiate(_copyObject, _itemContent);
            //     var langName = _objNewItem.transform.Find("Lang View Text").GetComponent<TextMeshProUGUI>();
            //     langName.text = item._languageSettings[this];

            // }
            for (int i = 0; i < _languageManagerSettings._languageSettings.Count; i++)
            {
                _objNewItem = Instantiate(_copyObject, _itemContent);
                var langName = _objNewItem.transform.Find("Lang View Text").GetComponent<TextMeshProUGUI>();
                langName.text = _languageManagerSettings._languageSettings[i].LangName.ToString();
                _objNewItem.name = _languageManagerSettings._languageSettings[i].LangName;
            }
        }
        public void Click(string lang)
        {
            ChangeTexts(lang);
        }
        void ChangeTexts(string lang)
        {
            switch (lang)
            {
                case "English": //English
                    var english = _languageManagerSettings._languageSettings[0];
                    _languageManagerSettings.CurrentLang = "English";
                    _langTextEng.text = english.LangText;
                    _settingsEng.text = english.SettingsText;
                    taptoStartEng.text = english.TapToStart;
                    break;
                case "Turkish": //Turkish
                    var turkish = _languageManagerSettings._languageSettings[1];
                    _languageManagerSettings.CurrentLang = "Turkish";
                    _settingsTurkish.text = turkish.SettingsText;
                    _langTextTurkish.text = turkish.LangText;
                    taptoStartTurkish.text = turkish.TapToStart;
                    break;
                default:
                    goto case "English";
            }
        }




    }
}
