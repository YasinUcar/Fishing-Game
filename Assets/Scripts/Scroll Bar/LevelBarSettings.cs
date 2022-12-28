
using UnityEngine;
namespace LevelBarScroll
{
    [CreateAssetMenu(menuName = "Level/LevelBarSettings", fileName = "LevelBar Settings")]
    public class LevelBarSettings : ScriptableObject
    {
        [SerializeField] private float _levelBarValue;
        [SerializeField] private float _increaseValue;
        [SerializeField] private float _reduceValue;
        public float LevelBarValue
        {
            get => _levelBarValue; set { _levelBarValue = value; }

        }
        public float IncreaseValue { get => _increaseValue; }
        public float ReduceValue { get => _reduceValue; }
    }
}