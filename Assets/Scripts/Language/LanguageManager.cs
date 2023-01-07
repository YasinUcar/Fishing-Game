using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Language.Manager
{

    public class LanguageManager : MonoBehaviour
    {
        [SerializeField] private GameObject _copyObject;
        [SerializeField] private Transform _itemContent;
        [SerializeField] private LanguageManagerSettings _languageManagerSettings;
        [SerializeField] private List<Image> _itemUnlock;

        private GameObject _objNewItem;
        [SerializeField]
        private TextMeshProUGUI _settingsText, _langText, _taptoStartText, _langButtonText, _characterButtonText, _rodButtonText, _winText, _lostText;

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
                _itemUnlock.Add(_objNewItem.transform.Find("TrickImage").GetComponent<Image>());
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
                    _langText.text = english.LangText;
                    _settingsText.text = english.SettingsText;
                    _taptoStartText.text = english.TapToStart;
                    _langButtonText.text = english.LangText;
                    _characterButtonText.text = english.ChacterButtonText;
                    _rodButtonText.text = english.RodButtonText;
                    _winText.text = english.EndScreenWinText;
                    _lostText.text = english.EndScreenLostText;
                    _languageManagerSettings._languageSettings[0].Unlock = true;
                    _languageManagerSettings._languageSettings[1].Unlock = false;

                    break;
                case "Turkish": //Turkish
                    var turkish = _languageManagerSettings._languageSettings[1];
                    _languageManagerSettings.CurrentLang = "Turkish";
                    _characterButtonText.text = turkish.ChacterButtonText;
                    _settingsText.text = turkish.SettingsText;
                    _langText.text = turkish.LangText;
                    _taptoStartText.text = turkish.TapToStart;
                    _langButtonText.text = turkish.LangText;
                    _rodButtonText.text = turkish.RodButtonText;
                    _winText.text = turkish.EndScreenWinText;
                    _lostText.text = turkish.EndScreenLostText;
                    _languageManagerSettings._languageSettings[0].Unlock = false;
                    _languageManagerSettings._languageSettings[1].Unlock = true;
                    break;
                default:
                    goto case "English";

            }
            ChangeUnlocks();
        }

        void ChangeUnlocks()
        {
            for (int i = 0; i < _languageManagerSettings._languageSettings.Count; i++)
            {

                if (_languageManagerSettings._languageSettings[i].Unlock == true)
                {
                    _itemUnlock[i].color = Color.green; //*TODO : this changes image
                }
                else
                {
                    _itemUnlock[i].color = new Color(0, 0, 0, 0);
                }
            }
        }
    }



}

