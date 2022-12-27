using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coin.Settings
{
    [CreateAssetMenu(menuName = "Coin", fileName = "New Coin Manager")]
    public class CoinSettings : ScriptableObject
    {

        public int TotalCoin { get; set; }

    }
}