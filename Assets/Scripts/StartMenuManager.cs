using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
            _startMenuObjects.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.25f);
        }

        private void DisableOrEnable(bool value, GameObject gameObject) //disable other game objects list
        {

            //for (int i = 0; i < gameObject.Count; i++)
            //{
            gameObject.SetActive(value);
            //}
        }
        public void TapToStart()
        {
            DisableOrEnable(true, _otherObjects);
            DisableOrEnable(false, _startMenuObjects);
        }
    }
}