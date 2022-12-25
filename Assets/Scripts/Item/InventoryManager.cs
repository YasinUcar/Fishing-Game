using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.InventoryManager
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;
        private void Awake()
        {
            Instance = this;
        }
    }

}