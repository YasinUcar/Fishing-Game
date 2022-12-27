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
                //*TODO : daha opitmize olabilir
                _objnewItem = Instantiate(InventoryItem, ItemContent);
                var itemIcon = _objnewItem.transform.Find("Item Icon").GetComponent<Image>();
                var itemName = _objnewItem.transform.Find("Item Name").GetComponent<TextMeshProUGUI>();
                var _itemCoin = _objnewItem.transform.Find("Coin/CoinTEXT").GetComponent<TextMeshProUGUI>();
                var _itemCount = _objnewItem.transform.Find("Locked/Fish Count").GetComponent<TextMeshProUGUI>();

                _itemCoin.text = item.Coin.ToString();
                _itemCount.text = item.FishCount.ToString();

                itemName.text = item.ItemName;
                itemIcon.sprite = item.Icon;

                _coinText.Add(_objnewItem.transform.Find("Coin/CoinTEXT").GetComponent<TextMeshProUGUI>());
            }

        }

        public void Add(ItemSettings item, int CoinValue, int FishCount)
        {
            _items.Add(item);
            item.Coin += CoinValue;
            item.FishCount += FishCount;
        }
        //TODO : DELETE
        // public void Remove(ItemSettings item)
        // {
        //     _items.Remove(item);
        // }
        // public void IncreaseCoin(ItemSettings item, int value)
        // {
        //     item.Coin += value;
        // }
        // public void IncreaseFish(ItemSettings item, int value)
        // {
        //     item.FishCount += value;
        // }
        public void Checked()
        {
            // TODO : Daha optiimize bir yol bul
            // Time.timeScale = 0f;
            for (int i = 0; i < _items.Count; i++)
            {

                if (_items[i].Unlock == true)
                {
                    var itemUnlock = _objnewItem.transform.Find("Locked/Item Lock").GetComponent<Image>();
                    itemUnlock.color = new Color(0, 0, 0, 0); //*TODO : this changes image
                }
            }
            for (int i = 0; i < _coinText.Count; i++)
            {
                _coinText[i].text = _items[i].Coin.ToString();
            }
        }



    }

}