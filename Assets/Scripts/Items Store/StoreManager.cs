using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Character;
using TMPro;
using UnityEngine.UI;
namespace Store.Manager
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private List<CharacterItemSettings> _characterItemSettings;
        [SerializeField] private List<CharacterItemSettings> _characterItemRodSettings;

        [SerializeField] private GameObject _characterInventoryItem, _characterRodItem;
        [SerializeField] Transform _characterItemContent, _characterRodContent;
        private GameObject _objChacterItem, _objRodItem;
        private List<CharacterItemSettings> _deneme;

        void Start()
        {
            SortChacterItems(_characterItemSettings);
            SortChacterItems(_characterItemRodSettings);
            OnStart();
        }

        void OnStart()
        {
            foreach (var item in _characterItemSettings)
            {
                _objChacterItem = Instantiate(_characterInventoryItem, _characterItemContent);
                var itemCoinText = _objChacterItem.transform.Find("itemCoinText").GetComponent<TextMeshProUGUI>();
                var itemIcon = _objChacterItem.transform.Find("ItemImage").GetComponent<Image>();

                itemCoinText.text = item.Value.ToString();
                itemIcon.sprite = item.Icon;
            }
            foreach (var item in _characterItemRodSettings)
            {
                _objRodItem = Instantiate(_characterRodItem, _characterRodContent);
                var itemCoinText = _objRodItem.transform.Find("itemCoinText").GetComponent<TextMeshProUGUI>();
                var itemIcon = _objRodItem.transform.Find("ItemImage").GetComponent<Image>();

                itemCoinText.text = item.Value.ToString();
                itemIcon.sprite = item.Icon;
            }
        }
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
    }
}