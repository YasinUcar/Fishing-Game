using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Item.InventoryManager;
using LevelBarScroll;
using UnityEngine.UI;
using Level;
using Audio.Manager;
using Score.Manager;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI _winLostText;
    [SerializeField] private AudioClip _caughtSFX;
    [SerializeField] private Image _fishImage;

    [SerializeField] private LevelSettings _level;
    private int _randomIndexFish;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OnStart();
        EventManager.NextFish += FishCaught;
        EventManager.NextFish += OnStart;
    }
    void OnStart()
    {
        _fishImage.sprite = _level._fishs[_randomIndexFish].Icon;

    }
    private void FishCaught()
    {

        InventoryManager.Instance.Add(_level._fishs[_randomIndexFish], _level._fishs[_randomIndexFish].Value, 1);
        _level._fishs[_randomIndexFish].Unlock = true;
        // InventoryManager.Instance.Add(_level._fishs[_randomIndexFish],
        //   _level._fishs[_randomIndexFish].Value);
        AudioManager.Instance.PlayAudio(_caughtSFX);
        ScoreManager.Instance.IncreaseScore(_level._fishs[_randomIndexFish].ItemScore);
        LevelBar.Instance.IncreaseValue();
        RandomIndexFish();
    }
    int RandomIndexFish()
    {
        return _randomIndexFish = Random.Range(0, _level._fishs.Count);
    }

    private void OnDestroy()
    {
        EventManager.NextFish -= FishCaught;
        EventManager.NextFish -= OnStart;

    }

}
