using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Settings;
using UnityEngine.UI;
using TMPro;
using Coin.Settings;
using Coin.Manager;
namespace Item.InventoryManager
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        public Transform ItemContent;
        public GameObject InventoryItem;

        [SerializeField] private List<ItemSettings> _items = new List<ItemSettings>();
        [SerializeField] private CoinSettings _coinSettings;
        [SerializeField] private List<TextMeshProUGUI> _coinText;
        [SerializeField] private List<Image> _itemUnlock;
        [SerializeField] private TextMeshProUGUI _totalCoinText;
        private GameObject _objnewItem;
        private int _itemsListLenght;


        private void Awake()
        {
            Instance = this;
            //TODO : DELETE       

            _coinSettings.TotalCoin = 5000;
        }
        private void Start()
        {
            OnStart();
            _itemsListLenght = _items.Count;
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
                _itemUnlock.Add(_objnewItem.transform.Find("Locked/Item Lock").GetComponent<Image>());

            }
            // _totalCoinText.text = _coinSettings.TotalCoin.ToString();
            CoinManager.Instance.ChangesCoinText();
        }
        private void Update()
        {
            //            print(_coinSettings.TotalCoin.ToString());
        }
        public void Add(ItemSettings item, int CoinValue, int FishCount)
        {
            _items.Add(item);
            item.Coin += CoinValue;
            item.FishCount += FishCount;
            _coinSettings.TotalCoin += CoinValue; //TODO : Optimize?
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

            for (int i = 0; i < _itemsListLenght; i++)
            {

                if (_items[i].Unlock == true)
                {
                    // var itemUnlock = _objnewItem.transform.Find("Locked/Item Lock").GetComponent<Image>();
                    _itemUnlock[i].color = new Color(0, 0, 0, 0); //*TODO : this changes image
                }
            }
            for (int i = 0; i < _coinText.Count; i++)
            {
                _coinText[i].text = _items[i].Coin.ToString();
                _coinSettings.TotalCoin += _items[i].Coin;
            }

            CoinManager.Instance.ChangesCoinText();
        }



    }

}