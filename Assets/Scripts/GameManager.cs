using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Item.InventoryManager;
using Level;
using LevelBarScroll;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI _winLostText;
    [SerializeField] private LevelSettings _level;
    [SerializeField] TextMeshProUGUI _levelText;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OnStart();
        EventManager.NextFish += FishCaught;
    }
    void OnStart()
    {
        _levelText.text = _level.name;
    }

    private void FishCaught()
    {

        int randomIndex = Random.Range(0, _level._fishs.Count);
        _winLostText.enabled = true;
        _winLostText.text = "";
        InventoryManager.Instance.Add(_level._fishs[randomIndex]);
        LevelBar.Instance.IncreaseValue();

    }


}
