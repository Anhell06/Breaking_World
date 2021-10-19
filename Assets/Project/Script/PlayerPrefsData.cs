using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPrefsData 
{
    private PlayerData playerData = new PlayerData();

    private const string KEY_PLAYER_PREF = "player data";

    private string saveData;
    private string loadData;

    public void AddEndedLevel(int levelNumber, int score)
    {
        int[] levelAndScore = new int[2] { levelNumber, score };
        playerData.EndedLevelScore.Add(levelAndScore);
    }
    
    public void AddNewInfinityScore (int point)
    {
        playerData.BestInfinityGameScore = point;
    }

    public void ChangeName(string name)
    {
        playerData.Name = name;
    }

    public void AddItem(int item)
    {
        playerData.ItemList.Add(item);
    }

    public void Save(PlayerData data)
    {
        saveData = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(saveData, KEY_PLAYER_PREF);
    }
    public void Load(PlayerData data)
    {
        loadData = PlayerPrefs.GetString(saveData);
        playerData = JsonUtility.FromJson<PlayerData>(loadData);
    }
 }
