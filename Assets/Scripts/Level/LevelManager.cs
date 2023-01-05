using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using TMPro;
namespace Level.Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<LevelSettings> _levels;
        [SerializeField] public LevelManagerSettings _levelManagerSettings;
        [SerializeField] TextMeshProUGUI _levelText, _mainMenulevelText;


        private void Start()
        {
            
            OnStart();
            EventManager.NextLevel += OnStart;
            EventManager.NextLevel += ChangeLevel;
        }
        void OnStart()
        {
            if (_levelManagerSettings.LevelCount <= _levels.Count - 1)
            {
                _levelText.text = _levels[_levelManagerSettings.LevelCount].name;
                _mainMenulevelText.text = _levels[_levelManagerSettings.LevelCount].name;
            }
            else
            {
                CurrentLevel();
                OnStart();
            }
        }
        public void ChangeLevel()
        {
            _levelManagerSettings.LevelCount++;
            OnStart();
        }
        public LevelSettings CurrentLevel()
        {
            if (_levelManagerSettings.LevelCount <= _levels.Count - 1)
                return _levels[_levelManagerSettings.LevelCount];
            else
            {
                _levelManagerSettings.LevelCount = 0;

                return _levels[_levelManagerSettings.LevelCount];
            }


        }
        private void OnDestroy()
        {
            EventManager.NextLevel -= OnStart;
            EventManager.NextLevel -= ChangeLevel;
        }
    }

}
