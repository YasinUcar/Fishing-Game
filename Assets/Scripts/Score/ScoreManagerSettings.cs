using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score.Manager
{
    [CreateAssetMenu(menuName = "Score", fileName = "New Score Manager")]
    public class ScoreManagerSettings : ScriptableObject
    {
        private float _currentScore;
        public float CurrentScore { get => _currentScore; set => _currentScore = value; }
    }
}