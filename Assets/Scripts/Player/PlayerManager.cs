using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
            OnStart();
        }
        private void OnStart()
        {
            EventManager.NextFish += TriggerCek;
        }

        public void TriggerCek()
        {
            _animator.SetTrigger("Çek");

        }
    }
}