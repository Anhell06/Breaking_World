using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelSetting", menuName = "Levels/defult_level", order = 51)]

public class LevelSettingSO : ScriptableObject
{
    [SerializeField]
    public int LevelNumber;
    [SerializeField]
    public int LevelDifficulty;
    [SerializeField]
    public List<AbstractBlock> BlockInLevel;
    [SerializeField]
    public List<ItemSO> ItemInLevel;
}
