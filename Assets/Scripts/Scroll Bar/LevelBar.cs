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
        [SerializeField] private LevelBarSettings _LevelBarSettings;
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private GameObject _winText, _loseText;

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
            _LevelBarSettings.LevelBarValue = 0;
        }
        void ScrollbarValue()
        {
            _scrollbar.size = _LevelBarSettings.LevelBarValue;
        }
        public void IncreaseValue()
        {
            if (_LevelBarSettings.IncreaseValue < 1)
            {
                _LevelBarSettings.LevelBarValue += _LevelBarSettings.IncreaseValue;

            }
            if (_LevelBarSettings.LevelBarValue >= 1)
            {
                OnStart();
                _loseText.SetActive(false);
                _winText.SetActive(true);
                EventManager.StartNextLevel();
                //_levelManager.ChangeLevel();
            }
            ScrollbarValue();
        }
        public void ReduceValue(int number)
        {
            _LevelBarSettings.LevelBarValue -= _LevelBarSettings.ReduceValue;
            ScrollbarValue();
        }
        private void OnDestroy()
        {
            EventManager.NextLevel -= OnStart;
            EventManager.GameOver -= OnStart;
        }

    }


}

