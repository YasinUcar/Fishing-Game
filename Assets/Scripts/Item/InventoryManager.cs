using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Settings;
using UnityEngine.UI;
using TMPro;
namespace Item.InventoryManager
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        public List<ItemSettings> Items = new List<ItemSettings>();
        public Transform ItemContent;
        public GameObject InventoryItem;
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
        public void ListItems()
        {
            foreach (var item in Items)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("Item Name").GetComponent<TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();

                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;


            }
        }
    }

}