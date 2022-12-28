using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item.Settings;
using LevelBarScroll;
namespace Level
{
    [CreateAssetMenu(menuName = "Level/Level Settings", fileName = "Level $")]
    public class LevelSettings : ScriptableObject
    {

        [SerializeField] public List<ItemSettings> _fishs;
        [SerializeField] public LevelBarSettings _levelBarSettings;

    }
}