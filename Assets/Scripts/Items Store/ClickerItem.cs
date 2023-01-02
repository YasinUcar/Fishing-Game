using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Store.Manager;
namespace Store.Clicker
{
    public class ClickerItem : MonoBehaviour
    {
        [SerializeField] private StoreManager _storeManager;


        private void Awake()
        {
            _storeManager = GameObject.FindGameObjectWithTag("Store").GetComponent<StoreManager>();
        }
        public void MouseClick()
        {
            _storeManager.Click(this.gameObject.name);
        }
    }
}