using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coin.Settings
{
    [CreateAssetMenu(menuName = "Coin", fileName = "New Coin Manager")]
    public class CoinSettings : ScriptableObject
    {
        //  TODO : Total coin aynı item settings'ler gibi + değerlerini içerisine alıyor buna daha uygun bir yol bul
        public int TotalCoin
        {
            get
            {
                return PlayerPrefs.GetInt("TotalCoin" + name);
            }
            set
            {
                PlayerPrefs.SetInt("TotalCoin" + name, value);
            }
        }

    }
}