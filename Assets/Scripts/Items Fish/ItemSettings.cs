using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Settings
{
    [CreateAssetMenu(menuName = "Items/Fish", fileName = "New Item Fish")]
    public class ItemSettings : ScriptableObject
    {
        [SerializeField] private int _id;
        public int ID { get => _id; }
        [SerializeField] private string _itemName;
        public string ItemName { get => _itemName; }
        [SerializeField] private int _value;
        public int Value { get => _value; }
        [SerializeField] private Sprite _icon;
        public Sprite Icon { get => _icon; set { _icon = value; } }

        //*TODO : İNCELE
        public bool Unlock
        {
            get
            {
                return PlayerPrefs.GetInt("UnlockFish" + name) == 1 ? true : false;
            }
            set
            {
                PlayerPrefs.SetInt("UnlockFish" + name, value == true ? 1 : 0);
            }
        }

        public int Coin
        {
            get
            {
                return PlayerPrefs.GetInt("CoinPlus" + name); //burda neden 1 yok
            }
            set
            {
                PlayerPrefs.SetInt("CoinPlus" + name, value);
            }
        }
        public int FishCount
        {
            get
            {
                return PlayerPrefs.GetInt("FishPlus" + name);
            }
            set
            {
                PlayerPrefs.SetInt("FishPlus" + name, value);
            }
        }


    }
}