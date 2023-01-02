using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Store.Manager;
namespace Store.Clicker
{
    public class ClickerItem : MonoBehaviour
    {
        private StoreManager _storeManager;


        private void Awake()
        {
            _storeManager = GameObject.FindGameObjectWithTag("Store").GetComponent<StoreManager>();
        }
        public void MouseClickItem()
        {
            _storeManager.ClickItem(this.gameObject.name);
        }
        public void MouseClickRod()
        {
            _storeManager.ClickRod(this.gameObject.name);
        }
    }
}