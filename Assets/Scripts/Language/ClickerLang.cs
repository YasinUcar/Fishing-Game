using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Language.Manager;
namespace Language.Clicker
{
    public class ClickerLang : MonoBehaviour
    {
        private LanguageManager _languageManager;

        private string currentLang;
        private void Awake()
        {
            _languageManager = GameObject.FindGameObjectWithTag("Lang").GetComponent<LanguageManager>();
        }


        public void MouseClick()
        {
            _languageManager.Click(this.gameObject.name);
        }

    }
}