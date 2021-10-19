using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private bool isWin;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private LevelSettingSO levelSetting;
    [SerializeField] private PlayerPrefsData saveLoadSystem;
    [SerializeField] private TimeChanger timeChanger = new TimeChanger();
    [SerializeField] private Player playerStatus;
    [SerializeField] private GameObject button;


    private void Start()
    {
        playerStatus.StatusChanged += LevelEnded;
    }


    private void StartNextLevel(int levelNumber)
    {
        levelNumber = levelSetting.LevelNumber;
        levelNumber++;

        sceneLoader.LoadLevel(levelNumber);
    }

    private void RestartLevel()
    {
            
    }
    private void LevelEnded(PlayerStatus playerStatus)
    {
        if(playerStatus == PlayerStatus.Win || playerStatus == PlayerStatus.Death)
        {
            endScreen.SetActive(true);
            timeChanger.Pause(); 

            if(playerStatus == PlayerStatus.Win)
            {
                button.SetActive(true);
            }
        }
    }



}
