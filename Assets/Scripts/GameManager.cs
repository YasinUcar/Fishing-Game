using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Item.InventoryManager;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] TextMeshProUGUI _winLostText;
    private void Awake()
    {
        Instance = this;
    }

    public void FishCaught()
    {
        _winLostText.enabled = true;
        _winLostText.text = "";
        
    }
}
