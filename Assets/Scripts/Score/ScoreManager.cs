using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using UnityEngine.UI;
using DG.Tweening;
using Level.Manager;
namespace Score.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;


        [SerializeField] private ScoreManagerSettings _scoreManagerSettings;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private Image[] _scoreIcons;
        [SerializeField] private GameObject _endLevelCanvas;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            EventManager.NextLevel += EnableEndLevelCanvas;
            EventManager.GameOver += EnableEndLevelCanvas;
            OnStart();
        }
        void OnStart()
        {
            _scoreManagerSettings.CurrentScore = 0;
        }
        public void EnableEndLevelCanvas()
        {
            _endLevelCanvas.SetActive(true);
            CheckScore(_levelManager.CurrentLevel());
        }

        public void IncreaseScore(float score)
        {
            _scoreManagerSettings.CurrentScore += score;
        }
        public void ReduceScore(int score)
        {
            _scoreManagerSettings.CurrentScore -= score;
        }
        public void CheckScore(LevelSettings levelSettings)
        {
            //TODO : SCORE OLAYLARI DAHA DETAYLI VE DÜZGÜN OLABİLİR
            if (levelSettings.TargetScore >= _scoreManagerSettings.CurrentScore)
            {
                for (int i = 0; i < 3; i++)
                {
                    _scoreIcons[i].fillAmount = 0f;
                    _scoreIcons[i].DOFillAmount(1, 3f);

                }
            }
            else if (levelSettings.TargetScore < _scoreManagerSettings.CurrentScore && _scoreManagerSettings.CurrentScore > 100f)
            {
                for (int i = 0; i < 2; i++)
                {
                    _scoreIcons[i].fillAmount = 0f;
                    _scoreIcons[i].DOFillAmount(1, 3f);

                }
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    _scoreIcons[i].fillAmount = 0f;
                    _scoreIcons[i].DOFillAmount(1, 3f);

                }
            }
        }
        private void OnDestroy()
        {
            EventManager.NextLevel -= EnableEndLevelCanvas;
            EventManager.GameOver -= EnableEndLevelCanvas;
        }
    }
}
