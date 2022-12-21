using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing.Bar
{
    [CreateAssetMenu(menuName = "Fishing/FishingBar", fileName = "FishingBar Settings")]
    public class FishingBarSettings : ScriptableObject
    {
        [SerializeField] private float _handleSpeed;
        public float HandleSpeed { get { return _handleSpeed; } }
    }
}