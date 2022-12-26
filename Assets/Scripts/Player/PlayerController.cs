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

        private bool _isExit;

        private bool _fishCaught;
        private void Start()
        {
            OnStart();
            EventManager.NextFish += OnStart;
        }
        void OnStart()
        {
            _progressBarSettings.ProgressBarValue = 0;
            StartCoroutine(ResetProgressBar());

        }
        IEnumerator ResetProgressBar()
        {
            yield return new WaitForSeconds(3f);
            _progressBarScrool.size = _progressBarSettings.ProgressBarValue;
            _fishCaught = false;
            yield return null;
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_fishCaught)
            {
                return;
            }
            _isExit = false;
            if (_progressBarScrool.size != 1)
            {
                _progressBarSettings.ProgressBarValue += _progressBarSettings.IncreaseValue;
                _progressBarScrool.size = _progressBarSettings.ProgressBarValue;
            }
            else
            {
                _fishCaught = true;
                EventManager.StartNextFish();
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