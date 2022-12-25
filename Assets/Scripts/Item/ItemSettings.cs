using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Settings
{
    [CreateAssetMenu(menuName = "Items/Fish", fileName = "New Item Fish")]
    public class ItemSettings : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private string itemName;
        [SerializeField] private int value;
        [SerializeField] private Sprite icon;
    }
}