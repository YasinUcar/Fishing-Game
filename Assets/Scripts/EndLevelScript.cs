using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StartManager;
using Player.Manager;
using Score.Manager;
namespace EndLevel
{
    public class EndLevelScript : MonoBehaviour
    {
        [SerializeField] private StartMenuManager _startMenuManager;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private GameObject _winText, _loseText;
        [SerializeField] private ScoreManagerSettings _scoreManagerSettings;
        public void ExitButton()
        {
            _startMenuManager.EnableMainCanvas();
            _winText.SetActive(false);
            _loseText.SetActive(false);
            _playerManager.ResetTriger();
            _scoreManagerSettings.CurrentScore = 0;


        }
    }
}