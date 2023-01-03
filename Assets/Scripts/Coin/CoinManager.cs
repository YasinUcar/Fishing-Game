using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Coin.Settings;
namespace Coin.Manager
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;
        [SerializeField] private TextMeshProUGUI[] _coinText;
        [SerializeField] private CoinSettings _coinSettings;
        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            OnStart();
        }
        void OnStart()
        {
            foreach (var item in _coinText)
            {
                item.text = _coinSettings.TotalCoin.ToString();
            }
        }
        public void ChangesCoinText()
        {
            OnStart();
        }
        public int CurrentCoin()
        {
            return _coinSettings.TotalCoin;
        }
        public void IncreaseCoin(int addCoin)
        {
            _coinSettings.TotalCoin += addCoin;
            ChangesCoinText();
        }
        public void ReduceCoin(int reduceCoin)
        {
            _coinSettings.TotalCoin -= reduceCoin;
            ChangesCoinText();
        }
    }
}