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
        [SerializeField] private GameObject[] _rodItems;

        [SerializeField]
        private GameObject _objChacterItem, _objRodItem;

        void Start()
        {
            SortChacterItems(_characterItemSettings);
            SortChacterItems(_characterItemRodSettings);
            OnStart();
            BuyItem(_storeManagerSettings.CurrentHad);
            BuyRod(_storeManagerSettings.CurrentRod);

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
        public void ClickItem(string item)
        {
            BuyItem(item);
        }
        public void ClickRod(string item)
        {
            BuyRod(item);
        }
        void BuyItem(string item)
        {
            switch (item)
            {
                case "CowboyHat":
                    _storeManagerSettings.CurrentHad = "CowboyHat";
                    ChangeItem("CowboyHat");
                    break;
                case "Crown":
                    _storeManagerSettings.CurrentHad = "Crown";
                    ChangeItem("Crown");
                    break;
                case "MagicianHat":
                    _storeManagerSettings.CurrentHad = "MagicianHat";
                    ChangeItem("MagicianHat");
                    break;
                case "PijamaHat":
                    _storeManagerSettings.CurrentHad = "PijamaHat";
                    ChangeItem("PijamaHat");
                    break;
                case "PillboxHat":
                    _storeManagerSettings.CurrentHad = "PillboxHat";
                    ChangeItem("PillboxHat");
                    break;
                case "PoliceHat":
                    _storeManagerSettings.CurrentHad = "PoliceHat";
                    ChangeItem("PoliceHat");
                    break;
                case "ShowerCap":
                    _storeManagerSettings.CurrentHad = "ShowerCap";
                    ChangeItem("ShowerCap");
                    break;
                case "SombreroHat":
                    _storeManagerSettings.CurrentHad = "SombreroHat";
                    ChangeItem("SombreroHat");
                    break;
                case "VikingHat":
                    _storeManagerSettings.CurrentHad = "VikingHat";
                    ChangeItem("VikingHat");
                    break;
                case "MinerHat":
                    _storeManagerSettings.CurrentHad = "MinerHat";
                    ChangeItem("MinerHat");
                    break;
                default:
                    _storeManagerSettings.CurrentHad = "Empty";
                    ChangeItem("Empty");
                    break;
            }
        }
        void BuyRod(string item)
        {
            switch (item)
            {
                case "Blue Rod":
                    _storeManagerSettings.CurrentRod = "Blue Rod";
                    ChangeRod("Blue Rod");
                    break;
                case "Green Rod":
                    _storeManagerSettings.CurrentRod = "Green Rod";
                    ChangeRod("Green Rod");
                    break;
                default:
                    _storeManagerSettings.CurrentRod = "Main Rod";
                    ChangeRod("Main Rod");
                    break;
            }
        }
        void ChangeItem(string weaponName)
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
        void ChangeRod(string rodName)
        {
            for (int i = 0; i < _rodItems.Length; i++)
            {
                if (_rodItems[i].gameObject.name == rodName)
                {
                    _rodItems[i].SetActive(true);
                }
                else
                {
                    _rodItems[i].SetActive(false);
                }
            }
        }
    }
}