using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StartManager;
using Audio.Manager;
namespace Player.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private StartMenuManager _startMenuManager;

        private Animator _animator;
        bool isClick;
        void Start()
        {
            _animator = GetComponent<Animator>();
            OnStart();
        }
        private void OnStart()
        {
            EventManager.NextFish += TriggerCek;
            EventManager.StartGame += StartingGameAnimation;
            EventManager.NextLevel += TriggerVictory;
            EventManager.GameOver += TriggerLose;
        }

        public void TriggerCek()
        {
            _animator.SetTrigger("Çek");
            // _startMenuManager.TapToStart(false);
            // StartingGameAnimation();

        }
        public void ResetTriger()
        {
            _animator.ResetTrigger("Victory");
            _animator.ResetTrigger("Defeat");
            _animator.SetBool("Idle", true);
        }
        void TriggerVictory()
        {
            _animator.SetBool("Idle", false);
            _animator.SetTrigger("Victory");

        }
        void TriggerLose()
        {
            _animator.SetBool("Idle", false);
            _animator.SetTrigger("Defeat");
        }
        void StartingGameAnimation()
        {
            //TODO : Bu animasyon mouse ile basıldığında yavaş yavaş oynayabilir mi?
            _animator.SetTrigger("OltaAt");
            StartCoroutine(PlayIdleAnimation());
        }
        IEnumerator PlayIdleAnimation()
        {
            yield return new WaitForSeconds(3f);
            _animator.SetBool("Idle", true);
            _startMenuManager.TapToStart(true);

            StopCoroutine(PlayIdleAnimation());
        }
        private void OnDestroy()
        {
            EventManager.NextFish -= TriggerCek;
            EventManager.StartGame -= StartingGameAnimation;
            EventManager.NextLevel -= TriggerVictory;
            EventManager.GameOver -= TriggerLose;
        }

    }
}