using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.ProgressBar;
using UnityEngine.UI;
using Store.Manager;
using Level.Manager;
namespace Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private ProgressBarSettings _progressBarSettings;
        [SerializeField] private Scrollbar _progressBarScrool;
        [SerializeField] private RectTransform _playerBarScroolTransform;
        [SerializeField] private Scrollbar _energyBar;
        [SerializeField] private Scrollbar _playerBarScrool;
        [SerializeField] private Transform _targetObject;
        [SerializeField] private float _lerpSpeed;
        [SerializeField] private GameObject _lostText, _winText;
        [SerializeField] private StoreManager _storeManager;
        [SerializeField] private LevelManager _levelManager;


        private bool _isExit;
        Vector3 startPlaybarTranform;
        private bool _fishCaught;
        private void Start()
        {
            startPlaybarTranform = _playerBarScrool.transform.position;
            OnStart();
            EventManager.NextFish += OnStart;
            EventManager.StartGame += ResetProgressBarStartGame;

        }

        void OnStart()
        {
            _progressBarSettings.ProgressBarValue = 0;
            StartCoroutine(ResetProgressBar());
        }
        void ResetProgressBarStartGame()
        {
            _progressBarSettings.ProgressBarValue = 0;
            _progressBarScrool.size = _progressBarSettings.ProgressBarValue;
            _fishCaught = false;
            _playerBarScrool.value = 0;
            _playerBarScrool.transform.position = startPlaybarTranform;

        }
        IEnumerator ResetProgressBar()
        {
            yield return new WaitForSeconds(3f);
            _progressBarScrool.size = _progressBarSettings.ProgressBarValue;
            _fishCaught = false;
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
            LerpPlayerBar();
            EnergyBar();
        }

        void LerpPlayerBar()
        {
            transform.position = Vector3.Lerp(transform.position, _targetObject.transform.position, _storeManager.RodPower() / _levelManager.CurrentRodDifficulty());
            float deneme = _levelManager.CurrentRodDifficulty();

        }
        void EnergyBar()
        {
            if (_isExit)
            {
                _energyBar.size -= 0.10f * Time.deltaTime;
                if (_energyBar.size <= 0)
                {
                    EventManager.StartGameOver();
                    _winText.SetActive(false);
                    _lostText.SetActive(true);

                }
            }
            else
            {
                _energyBar.size += 0.10f * Time.deltaTime;
            }

        }
        private void OnDestroy()
        {
            EventManager.NextFish -= OnStart;
            EventManager.StartGame -= ResetProgressBarStartGame;
        }
        public void LeftMovement()
        {
            _playerBarScrool.value -= _storeManager.RodPower();
            print("SOLA BASİLDİ");
        }
        public void RightMovement()
        {
            _playerBarScrool.value += _storeManager.RodPower();
            print("SAĞA BASİLDİ");
        }
    }

}