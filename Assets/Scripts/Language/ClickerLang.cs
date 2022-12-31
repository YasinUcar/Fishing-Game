using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Language.Manager;

public class ClickerLang : MonoBehaviour
{
    [SerializeField] private LanguageManagerSettings _languageManagerSettings;
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
