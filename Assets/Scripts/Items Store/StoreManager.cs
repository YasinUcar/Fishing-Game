using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Character;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Coin.Manager;
using Level.Manager;

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
        [SerializeField] CharacterItemSettings[] _listScriptableObjectsChacter;
        [SerializeField] CharacterItemSettings[] _listScriptableObjectsRod;
        [SerializeField] private List<Image> _itemUnlockItems, _itemUnlockRod;
        [SerializeField] private LevelManager _levelManager;

        [SerializeField]
        private GameObject _objChacterItem, _objRodItem;
        private float _powerRod;

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

                _itemUnlockItems.Add(_objChacterItem.transform.Find("ItemImage/UnlockImage").GetComponent<Image>());

            }
            foreach (var item in _characterItemRodSettings)
            {
                _objRodItem = Instantiate(_characterRodItem, _characterRodContent);
                var itemCoinText = _objRodItem.transform.Find("itemCoinText").GetComponent<TextMeshProUGUI>();
                var itemIcon = _objRodItem.transform.Find("ItemImage").GetComponent<Image>();

                _objRodItem.name = item.ItemName;
                itemCoinText.text = item.Value.ToString();
                itemIcon.sprite = item.Icon;

                _itemUnlockRod.Add(_objRodItem.transform.Find("ItemImage/UnlockImage").GetComponent<Image>());
            }
            CheckedUnlockItemImages();
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
                //TODO : AYNI BOOL DEĞİŞKEN İSMİ VEREMİYOR ÜSTE TANIMLASAM KABUL ETMİYOR?
                case "CowboyHat":
                    bool isChange = CheckedUnlockItem(_listScriptableObjectsChacter[0]);
                    if (isChange == true)
                    {
                        _storeManagerSettings.CurrentHad = "CowboyHat";
                        //   CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[0].Value);
                        ChangeItem("CowboyHat");
                    }

                    break;
                case "Crown":
                    bool isChange2 = CheckedUnlockItem(_listScriptableObjectsChacter[1]);
                    if (isChange2 == true)
                    {
                        _storeManagerSettings.CurrentHad = "Crown";
                        //  CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[1].Value);
                        ChangeItem("Crown");
                    }

                    break;
                case "MagicianHat":
                    bool isChange3 = CheckedUnlockItem(_listScriptableObjectsChacter[2]);
                    if (isChange3 == true)
                    {
                        _storeManagerSettings.CurrentHad = "MagicianHat";
                        //  CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[2].Value);
                        ChangeItem("MagicianHat");
                    }

                    break;
                case "PijamaHat":
                    bool isChange4 = CheckedUnlockItem(_listScriptableObjectsChacter[3]);
                    if (isChange4 == true)
                    {
                        _storeManagerSettings.CurrentHad = "PijamaHat";
                        //  CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[3].Value);
                        ChangeItem("PijamaHat");
                    }

                    break;
                case "PillboxHat":
                    bool isChange5 = CheckedUnlockItem(_listScriptableObjectsChacter[4]);
                    if (isChange5 == true)
                    {
                        _storeManagerSettings.CurrentHad = "PillboxHat";
                        //   CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[4].Value);
                        ChangeItem("PillboxHat");
                    }

                    break;
                case "PoliceHat":
                    bool isChange6 = CheckedUnlockItem(_listScriptableObjectsChacter[5]);
                    if (isChange6 == true)
                    {
                        _storeManagerSettings.CurrentHad = "PoliceHat";
                        //  CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[5].Value);
                        ChangeItem("PoliceHat");
                    }

                    break;
                case "ShowerCap":
                    bool isChange7 = CheckedUnlockItem(_listScriptableObjectsChacter[6]);
                    if (isChange7 == true)
                    {
                        _storeManagerSettings.CurrentHad = "ShowerCap";
                        //  CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[6].Value);
                        ChangeItem("ShowerCap");
                    }

                    break;
                case "SombreroHat":
                    bool isChange8 = CheckedUnlockItem(_listScriptableObjectsChacter[7]);
                    if (isChange8 == true)
                    {
                        _storeManagerSettings.CurrentHad = "SombreroHat";
                        // CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[7].Value);
                        ChangeItem("SombreroHat");
                    }

                    break;
                case "VikingHat":
                    bool isChange9 = CheckedUnlockItem(_listScriptableObjectsChacter[8]);
                    if (isChange9 == true)
                    {
                        _storeManagerSettings.CurrentHad = "VikingHat";
                        //CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[8].Value);
                        ChangeItem("VikingHat");
                    }

                    break;
                case "MinerHat":
                    bool isChange10 = CheckedUnlockItem(_listScriptableObjectsChacter[9]);
                    if (isChange10 == true)
                    {
                        _storeManagerSettings.CurrentHad = "MinerHat";
                        // CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[9].Value);
                        ChangeItem("MinerHat");
                    }
                    break;
                case "MainHat":
                    bool isChange11 = CheckedUnlockItem(_listScriptableObjectsChacter[10]);
                    if (isChange11 == true)
                    {
                        _storeManagerSettings.CurrentHad = "MainHat";
                        // CoinManager.Instance.ReduceCoin(_listScriptableObjectsChacter[9].Value);
                        ChangeItem("MainHat");
                    }
                    break;
                default:
                    _storeManagerSettings.CurrentHad = "Empty";
                    ChangeItem("Empty");
                    break;

            }
            CheckedUnlockItemImages();
        }
        void BuyRod(string item)
        {
            switch (item)
            {
                case "Wood Rod":
                    bool isChange = CheckedUnlockItem(_listScriptableObjectsRod[0]);
                    if (isChange == true)
                    {
                        _storeManagerSettings.CurrentRod = "Wood Rod";
                        CoinManager.Instance.ReduceCoin(_listScriptableObjectsRod[0].Value);
                        ChangeRod("Wood Rod");
                        _powerRod = _listScriptableObjectsRod[0].FishingRodLerpSpeed;
                    }
                    break;
                case "Green Rod":
                    bool isChange2 = CheckedUnlockItem(_listScriptableObjectsRod[1]);
                    if (isChange2 == true)
                    {
                        _storeManagerSettings.CurrentRod = "Green Rod";
                        CoinManager.Instance.ReduceCoin(_listScriptableObjectsRod[1].Value);
                        ChangeRod("Green Rod");
                        _powerRod = _listScriptableObjectsRod[1].FishingRodLerpSpeed;
                    }
                    break;
                default:
                    _storeManagerSettings.CurrentRod = "Blue Rod";
                    ChangeRod("Blue Rod");
                    _powerRod = _listScriptableObjectsRod[2].FishingRodLerpSpeed;
                    break;
            }
            CheckedUnlockItemImages();
            _levelManager.CurrentRodDifficulty();
        }
        public float RodPower()
        {
            return _powerRod;
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
        //TODO : Kötü bir yapı nesneleri çağırmak için ayrıca array kulanıyorum ve bunlar manuel akılda tutulmak zorunda
        bool CheckedUnlockItem(CharacterItemSettings character)
        {
            if (character.Unlock == false && CoinManager.Instance.CurrentCoin() >= character.Value)
            {
                character.Unlock = true;
                CoinManager.Instance.ReduceCoin(character.Value);
                return true;

            }
            else if (character.Unlock == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        void CheckedUnlockItemImages()
        {
            for (int i = 0; i < _characterItemSettings.Count; i++)
            {

                if (_characterItemSettings[i].Unlock == true)
                {
                    // var itemUnlock = _objnewItem.transform.Find("Locked/Item Lock").GetComponent<Image>();
                    _itemUnlockItems[i].color = new Color(0, 0, 0, 0); //*TODO : this changes image
                }
            }
            for (int i = 0; i < _characterItemRodSettings.Count; i++)
            {

                if (_characterItemRodSettings[i].Unlock == true)
                {
                    // var itemUnlock = _objnewItem.transform.Find("Locked/Item Lock").GetComponent<Image>();
                    _itemUnlockRod[i].color = new Color(0, 0, 0, 0); //*TODO : this changes image
                }
            }
        }
    }
}