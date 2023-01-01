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
    }
}