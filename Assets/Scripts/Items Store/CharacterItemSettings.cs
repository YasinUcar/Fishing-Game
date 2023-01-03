using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Character
{

    [CreateAssetMenu(menuName = "Items/Character", fileName = "New Item Character")]
    public class CharacterItemSettings : ScriptableObject
    {

        [SerializeField] private int _id;
        public int ID { get => _id; }
        [SerializeField] private string _itemName;
        public string ItemName { get => _itemName; }
        [SerializeField] private int _value;
        public int Value { get => _value; }
        [SerializeField] private Sprite _icon;
        public Sprite Icon { get => _icon; }
        [SerializeField] private float _fishingRodPower;
        public float FishingRodPower { get => _fishingRodPower; }
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
    }
}