using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Settings.Manager
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsCanvas;
        [SerializeField] private RectTransform _settings;
        [SerializeField] private List<GameObject> _otherObjects;
        private int _turn = 0;
        public void ClickSettings()
        {
            if (_turn % 2 == 0)
            {
                DisableOrEnable(false);
                _settingsCanvas.SetActive(true);
                _settings.DOAnchorPos(Vector2.zero, 0.25f);

            }
            else
            {
                _settingsCanvas.SetActive(false);
                DisableOrEnable(true);

            }
            _turn++;

        }
        private void DisableOrEnable(bool value)
        {

            for (int i = 0; i < _otherObjects.Count; i++)
            {
                _otherObjects[i].SetActive(value);
            }
        }
    }
}