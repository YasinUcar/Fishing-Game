using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StartManager;
using Player.Manager;
namespace EndLevel
{
    public class EndLevelScript : MonoBehaviour
    {
        [SerializeField] private StartMenuManager _startMenuManager;
        [SerializeField] private PlayerManager _playerManager;
        public void ExitButton()
        {
            _startMenuManager.EnableMainCanvas();
            _playerManager.ResetTriger();
            
        }
    }
}