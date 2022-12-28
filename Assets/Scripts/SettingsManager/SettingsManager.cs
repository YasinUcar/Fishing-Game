using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Audio.Manager;
namespace Settings.Manager
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsCanvas;
        [SerializeField] private RectTransform _settings;
        [SerializeField] private List<GameObject> _otherObjects;
        [SerializeField] private SettingsManagerSettings _settingsManagerSettings;
        [SerializeField] private Image _soundImage;
        [SerializeField] private Sprite _soundOnIcon;
        [SerializeField] private Sprite soundOffIcon;
        private int _turn = 0;

        private void Start()
        {
            SoundClicker();

        }
        private void Update()
        {
            print(_settingsManagerSettings.AudioMute);
        }
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

        private void DisableOrEnable(bool value) //disable other game objects list
        {

            for (int i = 0; i < _otherObjects.Count; i++)
            {
                _otherObjects[i].SetActive(value);
            }
        }
        public void SoundClicker()
        {

            if (_settingsManagerSettings.AudioMute == false)
            {
                AudioManager.Instance.MuteSound();
                _settingsManagerSettings.AudioMute = true;
            }
            else
            {
                AudioManager.Instance.UnMuteSound();
                _settingsManagerSettings.AudioMute = false;
            }

            UpdateButton();
        }
        private void UpdateButton()
        {
            if (_settingsManagerSettings.AudioMute == false)
            {

                _soundImage.sprite = _soundOnIcon;
            }
            else
            {
                _soundImage.sprite = soundOffIcon;
            }
        }
    }
}