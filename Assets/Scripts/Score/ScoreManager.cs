using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;
using UnityEngine.UI;
using Level.Manager;
using DG.Tweening;
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
           
            print(_scoreManagerSettings.CurrentScore);
            print(levelSettings.TargetScore);
            //TODO : SCORE OLAYLARI DAHA DETAYLI VE DÜZGÜN OLABİLİR
            if (_scoreManagerSettings.CurrentScore >= levelSettings.TargetScore)
            {
                for (int i = 0; i < 3; i++)
                {
                    _scoreIcons[i].fillAmount = 0f;
                    _scoreIcons[i].DOFillAmount(1, 3f);

                }
            }
            else if (_scoreManagerSettings.CurrentScore < levelSettings.TargetScore && _scoreManagerSettings.CurrentScore > 100f)
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
            EventManager.NextLevel -= OnStart;
            EventManager.GameOver -= OnStart;
        }
        private void Update()
        {


        }
    }
}
