using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Settings
{
    [CreateAssetMenu(menuName = "Items/Fish", fileName = "New Item Fish")]
    public class ItemSettings : ScriptableObject
    {
        [SerializeField] public int id;
        [SerializeField] public string itemName;
        [SerializeField] private int value;
        [SerializeField] public Sprite icon;
    }
}