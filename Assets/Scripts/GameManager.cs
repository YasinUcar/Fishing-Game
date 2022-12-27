using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Item.InventoryManager;
using Level;
using LevelBarScroll;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI _winLostText;
    [SerializeField] private LevelSettings _level;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] private Image _fishImage;
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
        _levelText.text = _level.name;
        RandomIndexFish();
        _fishImage.sprite = _level._fishs[_randomIndexFish].Icon;

    }
    private void FishCaught()
    {
        ShowTest();
        InventoryManager.Instance.Add(_level._fishs[_randomIndexFish], _level._fishs[_randomIndexFish].Value, 1);
        _level._fishs[_randomIndexFish].Unlock = true;
        // InventoryManager.Instance.Add(_level._fishs[_randomIndexFish],
        //   _level._fishs[_randomIndexFish].Value);

        LevelBar.Instance.IncreaseValue();
        RandomIndexFish();
    }
    int RandomIndexFish()
    {
        return _randomIndexFish = Random.Range(0, _level._fishs.Count);
    }
    private void ShowTest()
    {
        _winLostText.enabled = true;
        _winLostText.text = "";
    }
    private void OnDestroy()
    {
        EventManager.NextFish += FishCaught;
        EventManager.NextFish += OnStart;
    }

}
