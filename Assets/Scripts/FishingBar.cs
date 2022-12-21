using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Fishing.Bar
{
    public class FishingBar : MonoBehaviour
    {

        [SerializeField] private FishingBarSettings _fishingBarSettings;
        [SerializeField] private Scrollbar _handle;
        private bool maxX;
        private void Start()
        {

        }
        void Update()
        {
            HandleMovement();
            Bounds();
        }
        void HandleMovement()
        {
            if (!maxX)
            {
                _handle.value = _handle.value + _fishingBarSettings.HandleSpeed * Time.deltaTime;
            }
            else
            {
                _handle.value = _handle.value - _fishingBarSettings.HandleSpeed * Time.deltaTime;
            }

        }
        void Bounds()
        {
            if (_handle.value >= 1)
            {
                maxX = true;
            }
            if (_handle.value <= 0)
            {
                maxX = false;
            }
        }
    }
}