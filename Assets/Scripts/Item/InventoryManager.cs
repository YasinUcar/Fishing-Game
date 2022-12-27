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
        [SerializeField] private List<ItemSettings> _items = new List<ItemSettings>();

        public Transform ItemContent;
        public GameObject InventoryItem;
        private GameObject _objnewItem;
        [SerializeField] private List<TextMeshProUGUI> _coinText;
        private void Awake()
        {
            Instance = this;

        }
        private void Start()
        {
            OnStart();
        }
        private void OnStart()
        {
            foreach (var item in _items)
            {
                _objnewItem = Instantiate(InventoryItem, ItemContent);
                var itemIcon = _objnewItem.transform.Find("Item Icon").GetComponent<Image>();
                var itemName = _objnewItem.transform.Find("Item Name").GetComponent<TextMeshProUGUI>();
                var _itemCoin = _objnewItem.transform.Find("Coin/CoinTEXT").GetComponent<TextMeshProUGUI>();
                _itemCoin.text = item.Coin.ToString();
                itemName.text = item.ItemName;
                itemIcon.sprite = item.Icon;
                _coinText.Add(_objnewItem.transform.Find("Coin/CoinTEXT").GetComponent<TextMeshProUGUI>());
            }

        }
        private void Update()
        {
            print(_items[0].Coin.ToString());
        }
        public void Add(ItemSettings item)
        {
            _items.Add(item);
        }
        public void Remove(ItemSettings item)
        {
            _items.Remove(item);
        }
        public void IncreaseCoin(ItemSettings item, int value)
        {
            item.Coin += value;
        }
        public void Checked()
        {

            // Time.timeScale = 0f;
            for (int i = 0; i < _items.Count; i++)
            {
                _coinText[i].text = _items[i].Coin.ToString(); ;
                if (_items[i].Unlock == true)
                {
                    var itemUnlock = _objnewItem.transform.Find("Locked/Item Lock").GetComponent<Image>();
                    itemUnlock.sprite = default; //*TODO : this changes image

                }


            }
        }



    }

}