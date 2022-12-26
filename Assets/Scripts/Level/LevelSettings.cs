using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Settings;
namespace Level
{
    [CreateAssetMenu(menuName = "Level", fileName = "Level $")]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] public List<ItemSettings> _fishs;

    }
}