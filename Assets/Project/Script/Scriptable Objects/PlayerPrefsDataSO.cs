using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataSO : ScriptableObject
{
    PlayerData playerData = new PlayerData();

    const string keyPlayerPref = "key";

    private string saveData;
    private string loadData;

    public void AddEndedLevel(List<int[]> massive)
    {
        playerData.EndedLevelScore = massive;
    }
    
    public void AddNewInfinityScore (int point)
    {
        playerData.BestInfinityGameScore = point;
    }

    public void ChangeName(string name)
    {
        playerData.Name = name;
    }

    public void AddItem(List<int> item)
    {
        playerData.ItemList = item;
    }

    public void Save(PlayerData data)
    {
        saveData = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(saveData, keyPlayerPref);
    }
    public void Load(PlayerData data)
    {
        loadData = PlayerPrefs.GetString(saveData);
        playerData = JsonUtility.FromJson<PlayerData>(loadData);
    }
 }
