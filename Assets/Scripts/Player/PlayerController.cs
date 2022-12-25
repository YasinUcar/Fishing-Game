using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.ProgressBar;
using UnityEngine.UI;
using TMPro;
namespace Player.Controller
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private ProgressBarSettings _progressBarSettings;
        [SerializeField] private Scrollbar _progressBarScrool;
        [SerializeField] TextMeshProUGUI _winLostText;
        private bool _isExit;

        private void Start()
        {
            if (_progressBarSettings.ProgressBarValue != 0)
                _progressBarSettings.ProgressBarValue = 0;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _isExit = false;
            if (_progressBarScrool.size != 1)
            {
                _progressBarSettings.ProgressBarValue += _progressBarSettings.IncreaseValue;
                _progressBarScrool.size = _progressBarSettings.ProgressBarValue;
            }
            else
            {
                _winLostText.enabled = true;
                _winLostText.text = "You caught a Hamsi!";
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            _isExit = true;


        }
        private void Update()
        {
            if (_isExit && _progressBarSettings.ProgressBarValue > 0)
            {
                _progressBarSettings.ProgressBarValue -= _progressBarSettings.ReduceValue;
                _progressBarScrool.size = _progressBarSettings.ProgressBarValue;

            }

        }

    }
}