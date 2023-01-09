using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Settings;
using LevelBarScroll;

namespace Level
{
    [CreateAssetMenu(menuName = "Level/Level Settings", fileName = "Level $")]
    public class LevelSettings : ScriptableObject
    {

        [SerializeField] public List<ItemSettings> _fishs;
        [SerializeField] public LevelBarSettings _levelBarSettings;
        [SerializeField] private float _targetScore;
        

        public float TargetScore { get => _targetScore; }
        [SerializeField] private float _rodDifficultyBlue;
        [SerializeField] private float _rodDifficultyGreen;
        [SerializeField] private float _rodDifficultyWood;
        public float RodDifficultyBlue { get => _rodDifficultyBlue; }
        public float RodDifficultyGreen { get => _rodDifficultyGreen; }
        public float RodDifficultyWood { get => _rodDifficultyWood; }



    }
}