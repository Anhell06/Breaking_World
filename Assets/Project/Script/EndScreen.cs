using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private GameObject endScreen;
    [SerializeField]
    private bool isWin;
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private LevelSettingSO levelSetting;
    [SerializeField]
    private PlayerPrefsData saveLoadSystem;
    [SerializeField]
    private TimeChanger timeChanger;
    [SerializeField]
    private Player playerStatus;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject menuScreen;
    [SerializeField]
    private GameObject continueButton;



    private void Start()
    {
        playerStatus.StatusChanged += LevelEnded;
        playerStatus.StatusChanged += PlayerDeath;
    }


    public void StartNextLevel()
    {

        var levelNumber = levelSetting.LevelNumber;
        levelNumber++;
        sceneLoader.LoadLevel(levelNumber);
    }

    public void RestartLevel()
    {
        Debug.Log("Restart");
        sceneLoader.RestartLevel();
        timeChanger.SetTime(1);
    }
    public void LevelEnded(PlayerStatus playerStatus)
    {
        if (playerStatus == PlayerStatus.Win)
        {
            endScreen.SetActive(true);
            timeChanger.Pause();
            menuScreen.SetActive(false);
            endScreen.SetActive(false);
            winScreen.SetActive(true);
        }
    }

    private void PlayerDeath(PlayerStatus playerStatus)
    {
        if (playerStatus == PlayerStatus.Death)
        {
            endScreen.SetActive(true);
            timeChanger.Pause();
            continueButton.SetActive(false);
            menuScreen.SetActive(false);
            winScreen.SetActive(false);
        }

    }

    private void OnDestroy()
    {
        playerStatus.StatusChanged -= LevelEnded;
        playerStatus.StatusChanged -= PlayerDeath;
    }



}
