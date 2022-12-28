using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartManager
{
    public class StartMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _startMenuObjects;
        [SerializeField] private GameObject _otherObjects;
        void Start()
        {
            OnStart();
        }
        private void OnStart()
        {
            DisableOrEnable(false, _otherObjects);
        }

        private void DisableOrEnable(bool value, GameObject gameObject) //disable other game objects list
        {

            //for (int i = 0; i < gameObject.Count; i++)
            //{
            gameObject.SetActive(value);
            //}
        }
        private void Update()
        {
            print("Çaliştim");
            // if (Input.anyKey) // TODO : Mobilde çalışıyor mu?
            // {
            //     DisableOrEnable(true, _otherObjects);
            //     DisableOrEnable(false, _startMenuObjects);

            // }

        }
    }
}