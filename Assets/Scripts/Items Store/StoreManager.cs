using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Character;
using TMPro;
using UnityEngine.UI;
using System.Linq;

namespace Store.Manager
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private List<CharacterItemSettings> _characterItemSettings;
        [SerializeField] private List<CharacterItemSettings> _characterItemRodSettings;

        [SerializeField] private GameObject _characterInventoryItem, _characterRodItem;
        [SerializeField] Transform _characterItemContent, _characterRodContent;
        [SerializeField] private StoreManagerSettings _storeManagerSettings;
        //[SerializeField] private List<GameObject> _hadItems;
        [SerializeField] private GameObject[] _hadItems;
        
        [SerializeField]
        private GameObject _objChacterItem, _objRodItem;

        void Start()
        {
            SortChacterItems(_characterItemSettings);
            SortChacterItems(_characterItemRodSettings);
            OnStart();
            BuyItem(_storeManagerSettings.CurrentHad);
        }

        void OnStart()
        {


            foreach (var item in _characterItemSettings)
            {
                _objChacterItem = Instantiate(_characterInventoryItem, _characterItemContent);
                var itemCoinText = _objChacterItem.transform.Find("itemCoinText").GetComponent<TextMeshProUGUI>();
                var itemIcon = _objChacterItem.transform.Find("ItemImage").GetComponent<Image>();

                _objChacterItem.name = item.ItemName;
                itemCoinText.text = item.Value.ToString();
                itemIcon.sprite = item.Icon;
            }
            foreach (var item in _characterItemRodSettings)
            {
                _objRodItem = Instantiate(_characterRodItem, _characterRodContent);
                var itemCoinText = _objRodItem.transform.Find("itemCoinText").GetComponent<TextMeshProUGUI>();
                var itemIcon = _objRodItem.transform.Find("ItemImage").GetComponent<Image>();

                _objRodItem.name = item.ItemName;
                itemCoinText.text = item.Value.ToString();
                itemIcon.sprite = item.Icon;
            }
        }
        // void InstantiateHads()
        // {
        //     string path = "Prefabs/Items Chacter/Hats/";
        //     _hadItems = Resources.LoadAll<GameObject>(path).ToList();
        // }
        void SortChacterItems(List<CharacterItemSettings> newList) //Sorting List Value Volume
        {
            for (int i = 0; i <= newList.Count; i++)
            {

                for (int j = i; j < newList.Count; j++)
                {
                    if (newList[i].Value > newList[j].Value)
                    {
                        var gecici = newList[j];
                        newList[j] = newList[i];
                        newList[i] = gecici;
                    }
                }
            }
        }
        public void Click(string item)
        {
            BuyItem(item);
        }
        void BuyItem(string item)
        {
            switch (item)
            {
                case "CowboyHat":
                    _storeManagerSettings.CurrentHad = "CowboyHat";
                    ChangeWeapon("CowboyHat");
                    break;
                default:
                    _storeManagerSettings.CurrentHad = "Empty";
                    ChangeWeapon("Empty");
                    break;
            }
        }
        void ChangeWeapon(string weaponName)
        {
            for (int i = 0; i < _hadItems.Length; i++)
            {
                if (_hadItems[i].gameObject.name == weaponName)
                {
                    _hadItems[i].SetActive(true);
                }
                else
                {
                    _hadItems[i].SetActive(false);
                }
            }
        }
    }
}