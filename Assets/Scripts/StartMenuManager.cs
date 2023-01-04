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
            EventManager.NextLevel += OnStart;
        }

        private void OnStart()
        {
            DisableOrEnable(false, _otherObjects);
            _startMenuObjects.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.25f);
        }
        public void EnableMainCanvas()
        {
            DisableOrEnable(true, _startMenuObjects);
        }
        private void DisableOrEnable(bool value, GameObject gameObject) //disable other game objects list
        {

            //for (int i = 0; i < gameObject.Count; i++)
            //{
            gameObject.SetActive(value);
            //}
        }
        public void TapToStart(bool endIdleAnimation)
        {
            if (endIdleAnimation == true)
            {
                DisableOrEnable(true, _otherObjects);
            }

            else
            {
                EventManager.StartGameEvent();
            }
            DisableOrEnable(false, _startMenuObjects);
        }
        private void OnDestroy()
        {
            EventManager.NextLevel -= OnStart;
        }

    }
}