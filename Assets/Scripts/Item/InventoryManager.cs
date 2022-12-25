using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Settings;
namespace Item.InventoryManager
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        public List<ItemSettings> Items = new List<ItemSettings>();
        private void Awake()
        {
            Instance = this;
        }
        public void Add(ItemSettings item)
        {
            Items.Add(item);
        }
        public void Remove(ItemSettings item)
        {
            Items.Remove(item);
        }
    }

}