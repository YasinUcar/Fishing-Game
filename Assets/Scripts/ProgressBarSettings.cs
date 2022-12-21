using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.ProgressBar
{
    [CreateAssetMenu(menuName = "ProgressBar/ProgressBarSettings", fileName = "ProgressBar Settings")]
    public class ProgressBarSettings : ScriptableObject
    {
        [SerializeField] private float _progressBarValue;
        [SerializeField] private float _increaseValue;
        public float ProgressBarValue { get => _progressBarValue; set { _progressBarValue = value; } }
        public float IncreaseValue { get => _increaseValue; }

    }
}