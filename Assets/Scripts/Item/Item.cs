using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "Items/Fish", fileName = "New Item Fish")]
    public class Item : ScriptableObject
    {
        public int id;
        public string itemName;
        public int value;
        public Sprite icon;
    }
}