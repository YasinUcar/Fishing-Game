using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Level.Manager;
using Audio.Manager;
namespace LevelBarScroll
{
    public class LevelBar : MonoBehaviour
    {
        public static LevelBar Instance;
        [SerializeField] private LevelBarSettings[] _LevelBarSettings;
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private GameObject _winText, _loseText;
        [SerializeField] private LevelManagerSettings _levelManagerSettings;

        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            OnStart();
            EventManager.NextLevel += OnStart;
            EventManager.GameOver += OnStart;

        }
        void OnStart()
        {
            _LevelBarSettings[_levelManagerSettings.LevelCount].LevelBarValue = 0;
           
        }
        void ScrollbarValue()
        {
            _scrollbar.size = _LevelBarSettings[_levelManagerSettings.LevelCount].LevelBarValue;
        }
        public void IncreaseValue()
        {
            if (_LevelBarSettings[_levelManagerSettings.LevelCount].LevelBarValue < 1)
            {
                _LevelBarSettings[_levelManagerSettings.LevelCount].LevelBarValue += _LevelBarSettings[_levelManagerSettings.LevelCount].IncreaseValue;

            }
            if (_LevelBarSettings[_levelManagerSettings.LevelCount].LevelBarValue >= 1)
            {
                OnStart();
                EventManager.StartNextLevel();
                _loseText.SetActive(false);
                _winText.SetActive(true);
                //_levelManager.ChangeLevel();
            }
            ScrollbarValue();
        }
        public void ReduceValue(int number)
        {
            _LevelBarSettings[_levelManagerSettings.LevelCount].LevelBarValue -= _LevelBarSettings[_levelManagerSettings.LevelCount].ReduceValue;
            ScrollbarValue();
        }
        private void OnDestroy()
        {
            EventManager.NextLevel -= OnStart;
            EventManager.GameOver -= OnStart;
        }

    }


}

